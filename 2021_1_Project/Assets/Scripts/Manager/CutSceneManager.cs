using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager instance;

    private Animator _animator;
    
    private bool _isAllShow = true; // 모든 애니메이션을 다 보여줬는지를 판별하는 변수
    private int _index;

    private float _startTime;
    private float[] _timeStamp;

    private void Awake()
    {
        instance = this;
        GetCutScene();
    }

    public void GetCutScene()
    {
        // 노래에 맞는 컷씬 연출 프리팹 가져오기
        _animator = Resources.Load<Animator>("Cutscene/" + PlayMusicInfo.ReturnSongName() + "/" + PlayMusicInfo.ReturnSongName());
        if (_animator == null)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
        _animator = Instantiate(_animator);
        _animator.transform.SetParent(transform, false);

        // 컷씬 타이밍 저장 파일 가져오기
        List<string> _tempstringList = FileManager.ReadFile_TXT(PlayMusicInfo.ReturnSongName() + "_CS.txt", "Cutscene/" + PlayMusicInfo.ReturnSongName() + "/");

        // 타이밍 파일이 존재하는 경우에만 타임스탬프를 저장한다.
        if(_tempstringList != null)
        {
            // 갯수에 맞게 저장 후
            _timeStamp = new float[_tempstringList.Count];
            // 파싱
            for (int i = 0; i < _timeStamp.Length; i++)
                _timeStamp[i] = float.Parse(_tempstringList[i]);
        }
    }

    public void SetTime()
    {
        if(gameObject.activeSelf)
        {
            _startTime = Time.time; // 타임 설정 후
            _animator.Rebind();
            _isAllShow = false;
        }
    }

    public void ResetTime()
    {
        _index = 0;
        _isAllShow = true;
    }

    private void Update()
    {
        if (!_isAllShow)
        {
            for (int i = _index; i < _index + 1; i++)
            {
                if (_timeStamp[i] < Time.time - _startTime)
                {
                    _animator.SetTrigger("start");
                    _index++;
                    break;
                }
            }

            if (_index == _timeStamp.Length)
                _isAllShow = true;
        }
    }
}
