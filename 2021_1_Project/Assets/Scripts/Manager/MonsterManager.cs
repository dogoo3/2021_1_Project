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
    [SerializeField] private Image _redM_gauge = default;
    [SerializeField] private Image _blueM_gauge = default;
    [SerializeField] private Image _curtain = default;
    [SerializeField] private Color _failColor = default;
    [SerializeField] private Color _successColor = default;

    private List<MonsterState> _monsterState = new List<MonsterState>();
    private Dictionary<string, float> _gaugePoint = new Dictionary<string, float>();

    private bool _isStart;
    private int _monsterIndex = 0;
    private float _startTime;
    private string _monsterType;

    private void Awake()
    {
        instance = this;
        _gaugePoint.Add("AWESOME", 0.01f);
        _gaugePoint.Add("GOOD", 0.005f);
        _gaugePoint.Add("FAIL", -0.1f);
        _gaugePoint.Add("MISS", -0.1f);
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
        _monsterType = _type;
    }

    public void StartMusic()
    {
        if (_monsterType == "_A")
        {
            ActiveGauge(_redM_gauge);
        }
        else
        {
            ActiveGauge(_blueM_gauge);
        }
        _curtain.gameObject.SetActive(false);

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

    public void SetTime()
    {
        _startTime = Time.time;
        _isStart = true;
    }

    private void ActiveGauge(Image _gauge)
    {
        _gauge.color = _failColor;
        _gauge.gameObject.SetActive(true);
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
    }

    private void SetGauge(Image _gauge, string _judge)
    {
        _gauge.fillAmount = Mathf.Clamp(_gauge.fillAmount + _gaugePoint[_judge], 0, 1.0f);
        if (_gauge.fillAmount >= 0.6f)
            _gauge.color = _successColor;
        else
            _gauge.color = _failColor;
    }

    public void Init()
    {
        _redM_gauge.fillAmount = _blueM_gauge.fillAmount = 0f;
        _redM_gauge.color = _blueM_gauge.color = _failColor;
    }
}
