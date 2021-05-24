using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance;

    [SerializeField] private SelectMonster[] _monsters = default;
    [SerializeField] private Image _redM_gauge = default;
    [SerializeField] private Image _blueM_gauge = default;
    [SerializeField] private Image _curtain = default;
    [SerializeField] private Color _failColor = default;
    [SerializeField] private Color _successColor = default;

    private Dictionary<string, float> _gaugePoint = new Dictionary<string, float>();

    private string _monsterType;

    private void Awake()
    {
        instance = this;
        _gaugePoint.Add("AWESOME", 0.01f);
        _gaugePoint.Add("GOOD", 0.005f);
        _gaugePoint.Add("FAIL", -0.1f);
        _gaugePoint.Add("MISS", -0.1f);
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
