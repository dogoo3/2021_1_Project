using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public enum SlideArrow
{
    Left,
    Right,
    Up,
    Down,
}

public class LongNoteDepart : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField] private Image _departcircle = default, _line = default;
    
    private Vector2 _lineSize, _setlineSize, _touchPos, _betweenToParent, _lerpDpos, _lerpApos; // 변동시킬 판정선 사이즈, 복구시킬 판정선 사이즈, 터치 좌표, 도착 노트와의 간격
    // 선형보간 출발지, 도착지
    
    private Vector2 _orirect, _effrect; // 노트 표현시의 W/H값, 이펙트 표현시의 W/H값

    private Color _noteColor;

    private LongNote _longNote;

    private bool _isHit = false, _isEnd, _isAuto; // 노트 터치 여부, 노트 펼쳐짐 여부, 출발노트와 도착노트가 만났을 때
    private int _stopindex; // _stopOver 배열 인덱스
    private float _judgeValue, _lerpValue;
    private string _motionName = "", _judgeName, _sfxName; // 정상 판정시 수행할 캐릭터 애니메이션 변수, 첫 터치 시 판정

    [Header("성공시 이펙트 이미지")]
    [SerializeField] private Sprite _effectSprite = default;
    private Sprite _noteSprite;

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
        _longNote = GetComponentInParent<LongNote>();
    }
    private void OnEnable()
    {
        InvokeRepeating("BrightenNote", 0f, 0.05f);
        _departcircle.raycastTarget = true; // 터치 비활성화

        _noteColor = Color.gray;
        _noteColor.a = 0;
        _stopOver[0].SpreadNote(_movedepartcircle);

        _lerpValue = SetLerpValue();
        _lerpDpos = _longNote.transform.position;
        _lerpApos = _stopOverPoint[0].position;
    }

    private void Start()
    {
        _noteSprite = _departcircle.sprite;

        _orirect = Vector2.one * 200.0f;
        _effrect = Vector2.one * 300.0f;
    }
    private void OnDisable()
    {
        _isEnd = _isHit = false; // bool 초기화
        _line.gameObject.SetActive(true);
        _lineSize = _line.rectTransform.sizeDelta = _setlineSize; // 초기 라인 사이즈로 변경

        gameObject.transform.position = transform.parent.position; // 첫 위치로 초기화

        _departcircle.sprite = _noteSprite; // 원래 노트 스프라이트로 복구
        _departcircle.rectTransform.sizeDelta = _orirect; // 원래 노트 사이즈로 변경
        _departcircle.raycastTarget = true; // 터치 감지 활성화

        for (int i = 0; i < _stopOver.Length; i++) // 시작상태로 Origin 변경
            _stopOver[i].ResetFillOrigin();
    }

    private void Vibrate(long _millisec = 150)
    {
        Vibration.Vibrate(_millisec);
    }

    private void Hit(string _message)
    {
        _isHit = true;
        _line.gameObject.SetActive(false); // 판정선 비활성화
        switch (_message)
        {
            case "AWESOME":
            case "GOOD":
                ComboManager.instance.CreaseCombo();
                SoundManager.instance.PlaySFX(_sfxName);
                Vibrate();
                _stopindex = 0;
                _judgeName = _message;
                break;
            case "MISS":
            case "FAIL":
                _departcircle.raycastTarget = false;
                ComboManager.instance.ResetCombo();
                JudgeManager.instance.SetJudgeImage(_message);
                SetEdge.instance.SetEdgeImage("FAIL_" + SetNote.instance.SetMotion(_motionName, true).ToString() + "_EDGE");
                _departcircle.raycastTarget = false;
                if (IsInvoking("BrightenNote")) // 노트 생성 Invoke 해제
                    CancelInvoke("BrightenNote");
                InvokeRepeating("DarkenNote", 0f, 0.05f);
                _stopOver[_stopOver.Length - 1].InvokeRepeating("InActivePointImage", 0f, 0.05f);
                _isEnd = true;
                break;
        }
    }

    private void BrightenNote() // 노트 판정 이전까지 실행
    {
        _noteColor.a = Mathf.Clamp(_noteColor.a + 0.1f, 0f, 1f);
        _departcircle.color = _noteColor;
        _line.color = _noteColor;
        for (int i = 0; i < _stopOver.Length; i++)
            _stopOver[i].SetColor(_noteColor);

        // 활성화 상태로 변경
        if (_line.rectTransform.sizeDelta.x - _departcircle.rectTransform.sizeDelta.x < _failRange + 1.0f)
        {
            _departcircle.color = _line.color = _noteColor = Color.white;
            for (int i = 0; i < _stopOver.Length; i++)
                _stopOver[i].SetColor(_noteColor);
            CancelInvoke();
        }
    }
    private void DarkenNote() // 노트 판정 완료시 실행
    {
        _departcircle.color = _noteColor;
        _noteColor.a -= 0.1f; // 노트가 사라지는 상수값
        for (int i = 0; i < _stopOver.Length; i++)
            _stopOver[i].SetColor(_noteColor);

        if (_noteColor.a <= 0f) // 노트가 투명해지면 비활성화
        {
            CancelInvoke();
            NotePoolingManager.instance.InsertNote(_longNote);
        }
    }

    private float SetLerpValue()
    {
        return 0.000025f;
    }

    public void InputAnimation(string _motion)
    {
        _motionName = _motion;
    }

    public void InputSfxName(string _sfxName)
    {
        this._sfxName = _sfxName;
    }
    public void SetNoteProperties(float _linedistance, float _reduceValue, float _notemovespeed, bool _isAuto = false) // 노트의 초기 설정
    {
        Vector2 _lineValue;
        _lineValue.x = _lineValue.y = _linedistance;
        _lineSize = _setlineSize = _line.rectTransform.sizeDelta = _departcircle.rectTransform.sizeDelta + _lineValue;
        _movedepartcircle = _notemovespeed;
        this._reduceValue = _reduceValue;
        this._isAuto = _isAuto;
    }

    private void FixedUpdate()
    {
        if(!_isEnd)
        {
            if (_isHit) // 출발 노트가 움직이는 부분
            {
                if (_stopindex < _stopOver.Length) // 경유 노트 처리 및 방향벡터 설정
                {
                    _lerpValue += SetLerpValue();
                    transform.position = Vector2.Lerp(_lerpDpos, _lerpApos, _movedepartcircle * _lerpValue); // 출발지에서 도착지까지의 선형보간을 이용함.
                    _stopOver[_stopindex].SetFillAmount(transform.position); // 진행이 끝난 부분은 없애줌

                    if(_movedepartcircle * _lerpValue >= 1.0f)
                    {
                        ComboManager.instance.CreaseCombo(); // 각 경유노트의 목적지 도착 시 Combo 증가
                        JudgeManager.instance.SetJudgeImage(_judgeName);
                        _stopOver[_stopindex].SetFillAmount(0);
                        _stopOver[_stopOver.Length - 1].SetColor(_stopindex); // 출발노트가 지나가면서 중간의 포인트노트를 보이지 않게 하기 위함(도착노트에 등록된 리소스 활용)
                        _stopindex++;
                        _lerpValue = SetLerpValue();
                        Vibrate();
                        if (_stopindex < _stopOver.Length) // 인덱스 오버플로우 방지
                        {
                            _lerpDpos = _stopOverPoint[_stopindex-1].position; // 도착 위치 설정
                            _lerpApos = _stopOverPoint[_stopindex].position; // 출발 위치 설정
                        }
                    }
                }
                
                if (transform.position == _stopOverPoint[_stopOver.Length - 1].position) // 최종 목적지에 출발노트가 도착
                {
                    if (_judgeValue < _awesomeRange) // 실제 AWESOME 판정 처리
                        JudgeManager.instance.SetJudgeImage("AWESOME");
                    else if (_judgeValue < _goodRange) // 실제 GOOD 판정 처리
                        JudgeManager.instance.SetJudgeImage("GOOD");
                    else { }

                    SoundManager.instance.PlaySFX(_sfxName);
                    SetNote.instance.SetMotion(_motionName); // 애니메이션 작동
                    SetEdge.instance.SetEdgeImage(_motionName + "_EDGE");
                    _departcircle.sprite = _effectSprite;
                    _departcircle.rectTransform.sizeDelta = _effrect;
                    _departcircle.raycastTarget = false;
                    _noteColor = Color.white;
                    Vibrate();
                    InvokeRepeating("DarkenNote", 0f, 0.05f);
                    _isEnd = true;
                }
            }
            else // 판정선이 축소되는 부분
            {
                _lineSize.x -= _reduceValue * Time.deltaTime;
                _lineSize.y -= _reduceValue * Time.deltaTime;
                _line.rectTransform.sizeDelta = _lineSize;

                #region AutoMode
                if(_isAuto)
                {
                    _judgeValue = _line.rectTransform.sizeDelta.x - _departcircle.rectTransform.sizeDelta.x;
                    if (_judgeValue < _awesomeRange)
                        Hit("AWESOME");
                }
                #endregion
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

    public void OnPointerExit(PointerEventData eventData)
    {
        #region AutoMode
        if (_isAuto)
            return;
        #endregion
        if (!_isEnd)
        {
            if (IsInvoking("BrightenNote")) // 노트 생성 Invoke 해제
            {
                CancelInvoke("BrightenNote");
                ComboManager.instance.ResetCombo();
                JudgeManager.instance.SetJudgeImage("FAIL");
                SetEdge.instance.SetEdgeImage("FAIL_" + SetNote.instance.SetMotion(_motionName, true).ToString() + "_EDGE");
            }
            if (Vector3.Distance(transform.position, _stopOverPoint[_stopOver.Length - 1].position) > 5.0f) // 롱노트 진행중 중간에 이탈한경우
            {
                ComboManager.instance.ResetCombo();
                JudgeManager.instance.SetJudgeImage("FAIL");
                SetEdge.instance.SetEdgeImage("FAIL_" + SetNote.instance.SetMotion(_motionName, true).ToString() + "_EDGE");
            }
            _departcircle.color = Color.white;
            InvokeRepeating("DarkenNote", 0f, 0.05f);
            _stopOver[_stopOver.Length - 1].InvokeRepeating("InActivePointImage", 0f, 0.05f);
            _isEnd = true;
        }
    }
}
