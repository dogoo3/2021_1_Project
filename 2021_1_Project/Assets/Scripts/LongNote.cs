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

    private Image _departcircle, _line;

    private Vector3 _arrow, _setarrow, _pos, _setpos; // departCircle 진행방향, departCircle 시작 좌표값
    
    private Color _noteColor;

    private bool _isHit, _isSpread; // 노트 터치 여부, 노트 펼쳐짐 여부, 
    private int _stopindex; // _stopOver 배열 인덱스
    private float _judgeValue;

    [Header("경유노트")]
    [SerializeField] private LongNoteStopover[] _stopOver = default;
    [Header("경유노트의 방향전환 포인트")]
    [SerializeField] private Transform[] _stopOverPoint = default;
    [Header("도착 노트")]
    [SerializeField] private Transform _arriveCircle = default;
    [Header("판정선 축소 속도, 노트 이동속도")]
    [SerializeField] private float _reduceValue = default;
    [Tooltip("노트 이동속도와 라인이 생성되는 속도는 똑같음.")]
    [SerializeField] private float _movedepartcircle = default;
    [Header("판정 범위")]
    [SerializeField] private float _awesomeRange = default, _goodRange = default, _failRange = default, _missRange = default;

    float r;
    private void Awake()
    {
        _departcircle = GetComponent<Image>();
        _line = transform.GetChild(0).GetComponent<Image>(); // 판정선 이미지
    }
    private void Start()
    {
        _pos = _setpos = transform.position; // 초기 출발노트 좌표값 설정
        _isHit = false;
    }
    private void OnEnable()
    {
        InvokeRepeating("BrightenNote", 0f, 0.05f);

        _judgeText.text = ""; // Temp
        
        _noteColor = Color.gray;
        _noteColor.a = 0;
        _isSpread = true;

        _stopOver[0].SpreadNote(_movedepartcircle);
    }
    private void OnDisable()
    {
    }

    private void Hit(string _message)
    {
        _isHit = true;
        _judgeText.text = _message;
        _arrow = _setarrow = _stopOverPoint[0].transform.position - transform.position; // 첫 경유지 방향벡터 설정
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
            if(_stopindex < _stopOver.Length)
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
                        _arrow = _setarrow = (_stopOver[_stopindex].transform.position - transform.position).normalized; // 경유지 방향벡터 설정
                }
            }

            if(Vector3.Distance(transform.position,_stopOverPoint[_stopOver.Length-1].position) <= 5.0f)
            {
                transform.position = _setpos;
                _stopOver[0].SpreadNote(_movedepartcircle);
                for (int i = 0; i < _stopOver.Length; i++)
                    _stopOver[i].ResetFillOrigin();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isHit = true;
        _arrow = _setarrow = (_stopOver[0].transform.position - transform.position).normalized; // 첫 경유지 방향벡터 설정
        _stopindex = 0;
        //if(!_isHit)
        //{
        //    _judgeValue = _line.rectTransform.sizeDelta.x - _departcircle.rectTransform.sizeDelta.x;
        //    // 판정라인 설정
        //    if (_judgeValue < _awesomeRange)
        //        Hit("AWESOME");
        //    else if (_judgeValue < _goodRange)
        //        Hit("GOOD");
        //    else if (_judgeValue < _failRange)
        //        Hit("FAIL");
        //    else { }
        //}
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
