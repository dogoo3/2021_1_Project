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

public class LongNote : MonoBehaviour, IPointerDownHandler
{
    public Text _judgeText; // Temp Component

    private Image _departcircle, _line;

    private Vector3 _arrow, _setarrow, _pos, _setpos; // departCircle 진행방향, departCircle 시작 좌표값
    private Vector2 _lineSize, _setlineSize, _touchPos; // 변동시킬 판정선 사이즈, 복구시킬 판정선 사이즈, 터치 좌표

    private Color _noteColor;

    private bool _isHit, _isEnd; // 노트 터치 여부, 노트 펼쳐짐 여부, 출발노트와 도착노트가 만났을 때
    private int _stopindex; // _stopOver 배열 인덱스
    private float _judgeValue;

    [Header("경유노트, 마지막 인덱스는 도착노트")]
    [SerializeField] private LongNoteStopover[] _stopOver = default;
    [Header("경유노트의 방향전환 포인트")]
    [SerializeField] private Transform[] _stopOverPoint = default;
    [Header("판정선 축소 속도, 노트 이동속도")]
    [SerializeField] private float _reduceValue = default;
    [Tooltip("노트 이동속도와 라인이 생성되는 속도는 똑같음.")]
    [SerializeField] private float _movedepartcircle = default;
    [Header("판정 범위")]
    [SerializeField] private float _awesomeRange = default, _goodRange = default, _failRange = default, _missRange = default;
    
    private void Awake()
    {
        _departcircle = GetComponent<Image>();
        _line = transform.GetChild(0).GetComponent<Image>(); // 판정선 이미지
    }
    private void Start()
    {
        _pos = _setpos = transform.position; // 초기 출발노트 좌표값 설정
        _lineSize = _setlineSize = _line.rectTransform.sizeDelta; // 초기 판정선 크기 지정
        _isHit = false;
    }
    private void OnEnable()
    {
        InvokeRepeating("BrightenNote", 0f, 0.05f);

        _judgeText.text = ""; // Temp

        _noteColor = Color.gray;
        _noteColor.a = 0;

        _stopOver[0].SpreadNote(_movedepartcircle);
    }
    private void OnDisable()
    {
        _isEnd = _isHit = false; // bool 초기화
        _line.gameObject.SetActive(true);
        _lineSize = _line.rectTransform.sizeDelta = _setlineSize; // 초기 라인 사이즈로 변경

        transform.position = _setpos; // 첫 위치로 초기화

        for (int i = 0; i < _stopOver.Length; i++) // 시작상태로 Origin 변경
            _stopOver[i].ResetFillOrigin();
    }

    private void Hit(string _message)
    {
        _isHit = true;
        _line.gameObject.SetActive(false); // 판정선 비활성화
        switch (_message)
        {
            case "AWESOME":
            case "GOOD":
                _arrow = _setarrow = (_stopOver[0].transform.position - transform.position).normalized; // 첫 경유지 방향벡터 설정
                _stopindex = 0;
                break;
            case "FAIL":
            case "MISS":
                if (IsInvoking("BrightenNote")) // 노트 생성 Invoke 해제
                    CancelInvoke("BrightenNote");
                InvokeRepeating("DarkenNote", 0f, 0.05f);
                _isEnd = true;
                _judgeText.text = _message;
                break;
        }
    }

    private void BrightenNote()
    {
        _noteColor.a += 0.1f; // 노트가 보여지는 상수값
        _departcircle.color = _noteColor;
        _line.color = _noteColor;
        for (int i = 0; i < _stopOver.Length; i++)
            _stopOver[i].SetColor(_noteColor);

        // 활성화 상태로 변경
        if(_line.rectTransform.sizeDelta.x - _departcircle.rectTransform.sizeDelta.x < _failRange + 1.0f)
        {
            _departcircle.color = _line.color = _noteColor = Color.white;
            for (int i = 0; i < _stopOver.Length; i++)
                _stopOver[i].SetColor(_noteColor);
            CancelInvoke();
        }
    }
    private void DarkenNote()
    {
        _noteColor.a -= 0.1f; // 노트가 사라지는 상수값
        _departcircle.color = _noteColor;
        for (int i = 0; i < _stopOver.Length; i++)
            _stopOver[i].SetColor(_noteColor);

        if (_noteColor.a <= 0f) // 노트가 투명해지면 비활성화
        {
            CancelInvoke();
            transform.parent.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(!_isEnd)
        {
            if (_isHit) // 출발 노트가 움직이는 부분
            {
                if (_stopindex < _stopOver.Length) // 경유 노트 처리 및 방향벡터 설정
                {
                    _arrow *= _movedepartcircle * Time.deltaTime;
                    transform.position += _arrow;
                    _stopOver[_stopindex].SetFillAmount(transform.position);
                    _arrow = _setarrow;
                    if (Vector3.Distance(transform.position, _stopOverPoint[_stopindex].position) < 5.0f)
                    {
                        _stopOver[_stopindex].SetFillAmount(0);
                        _stopindex++;
                        if (_stopindex < _stopOver.Length)
                            _arrow = _setarrow = (_stopOver[_stopindex].transform.position - transform.position).normalized; // 다음 경유지 방향벡터 설정
                    }
                }

                if (Vector3.Distance(transform.position, _stopOverPoint[_stopOver.Length - 1].position) <= 5.0f) // 최종 목적지에 출발노트가 도착
                {
                    if (_judgeValue < _awesomeRange) // AWESOME
                    {
                        _judgeText.text = "AWESOME";
                        InvokeRepeating("DarkenNote", 0f, 0.05f);
                        _isEnd = true;
                    }
                    else if (_judgeValue < _goodRange) // GOOD
                    {
                        _judgeText.text = "GOOD";
                        InvokeRepeating("DarkenNote", 0f, 0.05f);
                        _isEnd = true;
                    }
                    else { }
                }

                //if (Vector2.Distance(transform.position, ) >= 125.0f)
                //    Hit("FAIL");
            }
            else // 판정선이 축소되는 부분
            {
                _lineSize.x -= _reduceValue * Time.deltaTime;
                _lineSize.y -= _reduceValue * Time.deltaTime;
                _line.rectTransform.sizeDelta = _lineSize;
                if (_line.rectTransform.sizeDelta.x < _departcircle.rectTransform.sizeDelta.x - _missRange)
                    Hit("MISS");
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_isHit)
        {
            _judgeValue = _line.rectTransform.sizeDelta.x - _departcircle.rectTransform.sizeDelta.x;
            // 판정라인 설정
            if (_judgeValue < _awesomeRange)
                Hit("AWESOME");
            else if (_judgeValue < _goodRange)
                Hit("GOOD");
            else if (_judgeValue < _failRange)
                Hit("FAIL");
            else { }
        }
    }
}
