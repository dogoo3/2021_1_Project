using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMotionManager : MonoBehaviour
{
    public static AttackMotionManager instance;

    [SerializeField] private GameOverManager _gameOverManager = default;

    [SerializeField] private GameObject[] _imageObj = default;

    private RuntimeAnimatorController _success;
    private RuntimeAnimatorController _fail;

    private Animator _animator;

    private bool _isAllShow = true;
    private int _index;
    private float _startTime;
    private float[] _timeStamp;

    private void Awake()
    {
        instance = this;

        _animator = GetComponent<Animator>();
    }

    public void GetMotion()
    {
        string _path = "AttackMotion/" + PlayMusicInfo.ReturnSongName(); // 연출을 보여줄 타이밍이 저장된 파일을 가져온다
        List<string> _tempstringList = FileManager.ReadFile_TXT(_path + "/timestamp.txt");
        if (_tempstringList != null)
        {
            // 갯수에 맞게 저장 후
            _timeStamp = new float[_tempstringList.Count];
            // 파싱
            for (int i = 0; i < _timeStamp.Length; i++)
                _timeStamp[i] = float.Parse(_tempstringList[i]);
        }

        _success = Resources.Load<RuntimeAnimatorController>(_path + "/Success"); // 방어 연출을 보여줄 애니메이션을 가져온다
        _fail = Resources.Load<RuntimeAnimatorController>(_path + "/Fail"); // 공격 연출을 보여줄 애니메이션을 가져온다

        SetTime();
    }

    public void SetTime()
    {
        _animator.runtimeAnimatorController = null;
        _startTime = Time.time; // 타임 설정 후
        _index = 0;
        ActiveObj(false);
        _isAllShow = false;
    }

    private void Show(float _gauge, float _criteria)
    {
        SetNote.instance.SetActiveImage(false);
        if(_gauge >= _criteria) // 성공
        {
            _animator.runtimeAnimatorController = _success;
        }
        else // 실패
        {
            _animator.runtimeAnimatorController = _fail;
        }
        ActiveObj(true);
    }

    public void ActiveObj(bool _is)
    {
        for (int i = 0; i < _imageObj.Length; i++)
            _imageObj[i].gameObject.SetActive(_is);
    }
    public void HideObj() // animator event func
    {
        for (int i = 0; i < _imageObj.Length; i++)
            _imageObj[i].gameObject.SetActive(false);
        SetNote.instance.SetActiveImage();
        BackgroundManager.instance.Change();
    }
    public void ResetGauge() // animator event func
    {
        MonsterManager.instance.Init();
    }
    public void PlaySfx(string _str) // animator event func
    {
        SoundManager.instance.PlaySFX(_str);
    }
    public void GameOver() // animator event func
    {
        _gameOverManager.Active();
    }
    private void Update()
    {
        if (!_isAllShow)
        {
            for (int i = _index; i < _index + 1; i++)
            {
                if (_timeStamp[i] < Time.time - _startTime)
                {
                    Show(MonsterManager.instance.ReturnGauge(), 0.6f); 
                    _index++;
                    break;
                }
            }

            if (_index == _timeStamp.Length)
                _isAllShow = true;
        }
    }
}
