using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class MonsterState
{
    public float _time { get; }
    public string _monster { get; }
    public bool _isactive { get; }

    public MonsterState(string _time, string _monster, string _isactive)
    {
        this._time = float.Parse(_time);
        this._monster = _monster;
        this._isactive = bool.Parse(_isactive);
    }
}

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance;

    [SerializeField] private SelectMonster[] _monsters = default;
    [SerializeField] private Sprite[] _monsterMotions = default;
    [SerializeField] private Sprite[] _idleMotion = default;
    [SerializeField] private Image _redM_gauge = default;
    [SerializeField] private Image _blueM_gauge = default;
    [SerializeField] private Image _curtain = default;
    [SerializeField] private Sprite _failGauge = default;
    [SerializeField] private Sprite _successGauge = default;
    private List<MonsterState> _monsterState = new List<MonsterState>();
    private Dictionary<string, float> _gaugePoint = new Dictionary<string, float>();

    private Color _curtainColor;

    private bool _isStart;
    private int _monsterIndex = 0, _motionRandIndex, _motionLength;
    private float _startTime;
    private string _monsterType, _oriType;

    private void Awake()
    {
        instance = this;
        _gaugePoint.Add("AWESOME", 0.01f);
        _gaugePoint.Add("GOOD", 0.005f);
        _gaugePoint.Add("FAIL", -0.1f);
        _gaugePoint.Add("MISS", -0.1f);

        _motionLength = _monsterMotions.Length / 2;
        _curtainColor = _curtain.color;
    }

    private void Update()
    {
        if(_monsterState != null)
        {
            if (_isStart)
            {
                if (Time.time - _startTime > _monsterState[_monsterIndex]._time) // 시간 경과 시
                {
                    if (_monsterState[_monsterIndex]._monster == "_A") // 몬스터 타입에 따라서
                    {
                        _monsters[0].gameObject.SetActive(_monsterState[_monsterIndex]._isactive); // 몬스터의 활성화 여부를 결정해줌
                    }
                    else
                    {
                        _monsters[1].gameObject.SetActive(_monsterState[_monsterIndex]._isactive);
                    }
                    _monsterIndex++; // 인덱스 올림
                    if (_monsterIndex >= _monsterState.Count) // 상태를 저장한 인덱스의 카운트까지 올라가면
                        _isStart = false; // 몬스터 상태 게산 종료
                }
            }
        }
    }

    public void ChoiceMonster(string _type)
    {
        if (_type == "_A") // Choice Red
        {
            _monsters[1].NonSelect();
        }
        else // Choice Blue
        {
            _monsters[0].NonSelect();
        }
        _monsterType = _oriType = _type;
    }

    public void StartMusic()
    {
        ActiveGauge(_redM_gauge);
        ActiveGauge(_blueM_gauge);
        InvokeRepeating("PullCurtain", 0f, 0.05f);

        List<string> _tempstringList = FileManager.ReadFile_TXT(PlayMusicInfo.ReturnSongName() + ".txt", "Monster/");

        if (_tempstringList != null)
        {
            for (int i = 0; i < _tempstringList.Count; i++)
            {
                string[] temp = _tempstringList[i].Split('/');
                _monsterState.Add(new MonsterState(temp[0], temp[1], temp[2]));
            }
            _tempstringList = null;
        }
        else
            _monsterState = null;
    }

    private void PullCurtain()
    {
        _curtainColor.a -= 0.05f;
        _curtain.color = _curtainColor;
        if (_curtain.color.a <= 0)
        {
            _curtain.gameObject.SetActive(false);
            CancelInvoke("PullCurtain");
        }
    }

    public void SetTime()
    {
        _startTime = Time.time;
        _monsterIndex = 0;
        _monsterType = _oriType;
        for (int i = 0; i < _monsters.Length; i++)
            _monsters[i].SetMotion(_idleMotion[i]);
        _isStart = true;
    }

    public void StopTime()
    {
        _isStart = false;
    }

    private void ActiveGauge(Image _gauge)
    {
        _gauge.sprite = _failGauge;
        _gauge.transform.parent.gameObject.SetActive(true);
    }

    public void CarculateGauge(string _judge)
    {
        if (_gaugePoint.ContainsKey(_judge))
        {
            if(_monsterType == "_A")
            {
                SetGauge(_redM_gauge, _judge);
            }
            else
            {
                SetGauge(_blueM_gauge, _judge);
            }
        }
        SetMotion(_judge);
    }

    private void SetMotion(string _judge)
    {
        if (_judge == "FAIL" || _judge == "MISS")
            return;

        for (int i = 0; i < _monsters.Length; i++)
        {
            if (_monsters[i].gameObject.activeSelf) // 몬스터가 비활성화되어있으면 연산을 진행하지 않는다.
            {
                _motionRandIndex = Random.Range(0, _motionLength); // 모션 번호 랜덤
                if (_monsters[i].GetMotionName() == _monsterMotions[_motionRandIndex + i * _motionLength].name) // 이전에 적용된 모션과 같은 모션일 경우
                {
                    _motionRandIndex++; // 모션 번호를 1 올리고
                    if (_motionRandIndex >= _motionLength) // 모션의 범위를 벗어나는 경우(오버플로우 방지)
                        _motionRandIndex = 0; // 처음 모션으로 바꿔 적용해준다.
                }
                _monsters[i].SetMotion(_monsterMotions[_motionRandIndex + i * _motionLength]); // 모션을 적용한다.
            }
        }
    }

    private void SetGauge(Image _gauge, string _judge)
    {
        _gauge.fillAmount = Mathf.Clamp(_gauge.fillAmount + _gaugePoint[_judge], 0, 1.0f);
        Debug.Log(_gauge.fillAmount);
        if (_gauge.fillAmount >= 0.6f)
            _gauge.sprite = _successGauge;
        else
            _gauge.sprite = _failGauge;
    }

    public float ReturnGauge()
    {
        if (_monsterType == "_A")
            return _redM_gauge.fillAmount;
        else
            return _blueM_gauge.fillAmount;
    }

    public void Init()
    {
        _redM_gauge.fillAmount = _blueM_gauge.fillAmount = 0f;
        _redM_gauge.sprite = _blueM_gauge.sprite = _failGauge;
    }

    public void ChangeMonsterType(string _type)
    {
        _monsterType = _type;
    }
}
