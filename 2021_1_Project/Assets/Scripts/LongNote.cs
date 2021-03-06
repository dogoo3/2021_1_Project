using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum SlideArrow
{
    Left,
    Right,
    Up,
    Down,
}

public class LongNote : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public Text _judgeText; // Temp Component

    private Image _departcircle, _arrivecircle, _line;

    private Vector3 _arrow, _setarrow, _pos, _setpos; // departCircle 진행방향, departCircle 시작 좌표값
    
    private Color _noteColor;

    private bool _isHit, _isSpread; // 노트 터치 여부, 노트 펼쳐짐 여부, 

    private float _fillCalc;

    [Header("출발지(First), 경유지, 목적지(Last)")]
    [SerializeField] private Transform[] _point = default;
    [Header("판정선 축소 속도, 노트 이동속도")]
    [SerializeField] private float _reduceValue = default;
    [Tooltip("노트 이동속도와 라인이 생성되는 속도는 똑같음.")]
    [SerializeField] private float _movedepartcircle = default;
    [Header("판정 범위")]
    [SerializeField] private float _awesomeRange = default, _goodRange = default, _failRange = default, _missRange = default;

    int i = 0;
    private void Awake()
    {
        _departcircle = GetComponent<Image>();
        _arrivecircle = transform.parent.GetComponent<Image>(); // 도착 노트 이미지
        _line = transform.GetChild(0).GetComponent<Image>(); // 판정선 이미지
    }
    private void Start()
    {
        _pos = _setpos = transform.position; // 초기 출발노트 좌표값 설정
        _isHit = false;
        _fillCalc = 1 / _arrivecircle.rectTransform.sizeDelta.x;
    }
    private void OnEnable()
    {
        InvokeRepeating("BrightenNote", 0f, 0.05f);

        _judgeText.text = ""; // Temp

        _arrow = _setarrow = (_point[1].position - _point[0].position).normalized; // 첫 진행 방향 설정
        _noteColor = Color.gray;
        _noteColor.a = 0;
        _isSpread = true;
    }
    private void OnDisable()
    {
        _arrivecircle.fillOrigin = 1; // Right
        _arrivecircle.fillAmount = 0;
    }

    private void BrightenNote()
    {
        _noteColor.a += 0.1f;
        _departcircle.color = _noteColor;
        _line.color = _noteColor;

        if(_line.rectTransform.sizeDelta.x - _departcircle.rectTransform.sizeDelta.x < _failRange + 1.0f)
        {
            _departcircle.color = _line.color = _noteColor = Color.white;
            CancelInvoke();
        }
    }
    private void DarkenNote()
    {

    }

    private void Update()
    {
        if (_isHit) // 출발 노트가 움직이는 부분
        {
            if (i < _point.Length - 1)
            {
                if (Vector3.Distance(transform.position, _point[i + 1].position) <= 5.0f)
                {
                    i++;
                    if (i < _point.Length - 1)
                        _arrow = _setarrow = (_point[i + 1].position - _point[i].position).normalized; // 새로운 진행 방향 설정
                }
                _arrow *= _movedepartcircle * Time.deltaTime;
                transform.position += _arrow;
                _arrivecircle.fillAmount = Mathf.Abs(transform.position.x - _arrivecircle.transform.position.x) * _fillCalc;
                _arrow = _setarrow;
            }

            if (Vector3.Distance(transform.position, _point[_point.Length-1].position) <= 5.0f) // 100.0f는 노트의 반지름 상수값.
            {
                i = 0;
                // OnPointerDown에서 잡은 판정선 따라 판정처리
                transform.position = _pos = _setpos;
                _arrow = _setarrow = (_point[1].position - _point[0].position).normalized; // 새로운 진행 방향 설정
            }
        }
        else if (_isSpread) // 노트가 생성되는 부분
        {
            _arrow *= _movedepartcircle * Time.deltaTime;
            _pos += _arrow;
            _arrivecircle.fillAmount += _arrow.magnitude * _fillCalc;
            _arrow = _setarrow;

            if (_arrivecircle.fillAmount == 1.0f)
            {
                _arrivecircle.fillOrigin = 0; // LEFT
                i = 0;
                _isSpread = false;
                _arrow = _setarrow = (_point[1].position - _point[0].position).normalized; // 새로운 진행 방향 설정
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isHit = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
