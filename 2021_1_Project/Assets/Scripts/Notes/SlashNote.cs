using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlashNote : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _circle = default, _line = default, _arrow = default;

    [Header("성공시 이펙트 이미지")]
    [SerializeField] private Sprite _effectSprite = default;
    [Header("노트 이름")]
    [SerializeField] private string _notename = default;

    [Header("판정선 축소 속도")]
    [SerializeField] private float _reduceValue = 250.0f;
    [Header("판정 범위")]
    [SerializeField] private float _awesomeRange = default, _goodRange = default, _failRange = default, _missRange = default;

    private Vector2 _lineSize, _setlineSize; // 변동시킬 판정선 사이즈, 복구시킬 판정선 사이즈
    private Vector2 _orirect, _effrect; // 노트 표현시의 W/H값, 이펙트 표현시의 W/H값
    private Color _noteColor;
    private Sprite _noteSprite; // 이펙트 노트와의 반복을 위해 저장
    private bool _isHit = false, _isAuto, _isJudgeEnd;
    private float _judgeValue; // 판정 범위를 저장할 변수
    private string _judgeText; // 판정 이름

    [Space(20)]

    [Header("양수는 1,2사분면, 음수는 3,4사분면, 숫자가 커질수록 왼쪽으로, 0은 오른쪽으로 슬래시를 의미함.")]
    [Range(-180, 180)]
    [SerializeField] private float _angle = 0.0f;
    [Header("슬래시 허용 각도 범위")]
    [Range(40, 80)]
    [SerializeField] private float _range = 60.0f;
    [Header("슬래시 터치 시간(N초 안에 터치했다 떼야 함)")]
    [Range(0.1f, 0.60f)]
    [SerializeField] private float _slashTime = 0.1f;

    private Vector2 _touchdownPos, _touchupPos, _standardAxis;
    private bool _isTouch = false;
    private float _touchTime = 0f;
    private string _sfxName, _motionName;

    private void Awake()
    {
        _standardAxis = new Vector2(Mathf.Cos(_angle * Mathf.Deg2Rad), Mathf.Sin(_angle * Mathf.Deg2Rad));
    }

    private void Start()
    {
        _noteSprite = _circle.sprite;
        _orirect = Vector2.one * 200.0f;
        _effrect = Vector2.one * 300.0f;
    }

    private void OnEnable()
    {
        InvokeRepeating("BrightenNote", 0f, 0.05f);
        _isJudgeEnd = false;
        _noteColor = Color.gray;
        _noteColor.a = 0;
    }

    private void FixedUpdate()
    {
        if(!_isJudgeEnd)
        {
            if (!_isTouch)
            {
                _lineSize.x -= _reduceValue * Time.deltaTime;
                _lineSize.y -= _reduceValue * Time.deltaTime;
                _line.rectTransform.sizeDelta = _lineSize;
                #region AUTOMODE
                if(PlayMusicInfo.ReturnAutoMode())
                {
                    if (_line.rectTransform.sizeDelta.x < _circle.rectTransform.sizeDelta.x) // 노트를 놓치는 판정 범위
                    {
                        _line.color = Color.clear;
                        Hit("AWESOME");
                    }
                }
                else
                {
                    if (_line.rectTransform.sizeDelta.x < _circle.rectTransform.sizeDelta.x - _missRange) // 노트를 놓치는 판정 범위
                        Hit("MISS");
                }
                #endregion
            }
            else
            {
                _touchTime += Time.deltaTime;
                if (_touchTime > _slashTime)
                    Hit("FAIL");
            }
        }
    }

    private void OnDisable()
    {
        _lineSize = _line.rectTransform.sizeDelta = _setlineSize; // 초기 라인 사이즈로 복구
        _circle.sprite = _noteSprite; // 원래 노트 스프라이트로 복구
        _circle.rectTransform.sizeDelta = _orirect; // 원래 노트 사이즈로 변경
        _circle.raycastTarget = true; // 터치 감지 활성화
        _arrow.gameObject.SetActive(true);
        _isHit = false;
        _isTouch = false;
    }

    private void BrightenNote()
    {
        _noteColor.a = Mathf.Clamp(_noteColor.a + 0.1f, 0f, 1f);
        _circle.color = _noteColor;
        _line.color = _noteColor;
        _arrow.color = _noteColor;
        if (_line.rectTransform.sizeDelta.x - _circle.rectTransform.sizeDelta.x < _failRange + 1.0f) // Fail 판정시 Note가 밝아지지 않은 경우도 있기 때문에 미세한 값 수정
        {
            _circle.color = _line.color = _arrow.color = _noteColor = Color.white;
            _isHit = true; // 노트 터치 가능
            CancelInvoke("BrightenNote");
        }
    }
    private void DarkenNote()
    {
        _noteColor.a -= 0.1f; // 노트가 사라지는 상수값
        _circle.color = _noteColor;
        if(_arrow.gameObject.activeSelf)
            _arrow.color = _noteColor;
        if (_noteColor.a <= 0f) // 노트가 투명해지면 비활성화
        {
            CancelInvoke();
            gameObject.SetActive(false);
            NotePoolingManager.instance.InsertNote(this);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_isHit)
        {
            // 판정 정하기(처음에 터치할 때 판정이 정해지고, 슬래시에 성공하면 그 판정이 처리됨)
            _judgeValue = _line.rectTransform.sizeDelta.x - _circle.rectTransform.sizeDelta.x;
            // 판정라인 설정
            if (_judgeValue < _awesomeRange)
                SetJudgeText("AWESOME");
            else if (_judgeValue < _goodRange)
                SetJudgeText("GOOD");
            else if (_judgeValue < _failRange)
                Hit("FAIL");
            else { }

            _touchdownPos = eventData.position;
            _isTouch = true;
            _touchTime = 0f;
        }
    }

    public void SetNoteProperties(float _linedistance, float _reduceValue, bool _isAuto = false)
    {
        Vector2 _lineValue;
        _lineValue.x = _lineValue.y = _linedistance;
        _lineSize = _setlineSize = _line.rectTransform.sizeDelta = _circle.rectTransform.sizeDelta + _lineValue;
        this._reduceValue = _reduceValue;
        this._isAuto = _isAuto;
    }

    public string GetNoteName()
    {
        return _notename;
    }

    public void InputSfxName(string _sfxName)
    {
        this._sfxName = _sfxName;
    }
    
    public void InputAnimation(string _motion)
    {
        _motionName = _motion;
    }

    private void SetJudgeText(string _judge)
    {
        _judgeText = _judge;
        _line.color = Color.clear;
    }

    private void Vibrate(long _millisec = 150)
    {
        Vibration.Vibrate(_millisec);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(_isHit && _isTouch)
        {
            if(_touchTime <= _slashTime)
            {
                _touchupPos = eventData.position;
                _isTouch = false;
                if (Vector2.Distance(_touchdownPos, _touchupPos) >= 500.0f)
                    CheckRange(GetAngle(_touchupPos - _touchdownPos, _standardAxis));
                else
                    Hit("FAIL");
            }
        }
    }

    private void Hit(string _message)
    {
        switch(_message)
        {
            case "AWESOME":
            case "GOOD":
                SetNote.instance.SetMotion(_motionName);
                SetEdge.instance.SetEdgeImage(_motionName + "_EDGE");
                ComboManager.instance.CreaseCombo();
                SoundManager.instance.PlaySFX(_sfxName);
                Vibrate();
                _circle.sprite = _effectSprite;
                _circle.rectTransform.sizeDelta = _effrect;
                _arrow.gameObject.SetActive(false);
                // 성공 판정
                break;
            case "FAIL":
            case "MISS":
                SetNote.instance.SetMotion(_motionName, true);
                ComboManager.instance.ResetCombo();
                _line.color = Color.clear;
                _isHit = false;
                break;
        }
        _isJudgeEnd = true;
        JudgeManager.instance.SetJudgeImage(_message);
        SetMonsterGauge(_message);
        _motionName = "";
        _circle.raycastTarget = false;
        if (IsInvoking("BrightenNote"))
            CancelInvoke();
        InvokeRepeating("DarkenNote", 0f, 0.05f);
    }

    private void SetMonsterGauge(string _message)
    {
        if (MonsterManager.instance != null)
            MonsterManager.instance.CarculateGauge(_message);
    }

    private void CheckRange(float _angle)
    {
        if (_angle <= _range * 0.5f)
            Hit(_judgeText);
        else
            Hit("FAIL");
    }

    private float GetAngle(Vector2 a, Vector2 b)
    {
        float normA, normB;
        normA = Mathf.Sqrt(a.x * a.x + a.y * a.y);
        normB = Mathf.Sqrt(b.x * b.x + b.y * b.y);

        return 57.29578f * Mathf.Acos(Vector2.Dot(a, b) / (normA * normB));
    }
}
