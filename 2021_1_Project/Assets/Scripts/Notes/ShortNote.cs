using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShortNote : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image _circle = default, _line = default;

    [Header("성공시 이펙트 이미지")]
    [SerializeField] private Sprite _effectSprite = default;
    [Header("노트 이름")]
    [SerializeField] private string _notenane = default;

    private Sprite _noteSprite;
    private bool _isHit, _isAuto; // 노트 터치 여부

    private float _judgeValue; // 판정 범위를 저장할 변수

    private string _motionName = "", _sfxName; // 정상 판정시 수행할 캐릭터 애니메이션 변수

    private Vector2 _lineSize, _setlineSize; // 변동시킬 판정선 사이즈, 복구시킬 판정선 사이즈
    private Vector2 _orirect, _effrect; // 노트 표현시의 W/H값, 이펙트 표현시의 W/H값
    private Color _noteColor;

    [Header("판정선 축소 속도")]
    [SerializeField] private float _reduceValue = 250.0f;
    [Header("판정 범위")]
    [SerializeField] private float _awesomeRange = default, _goodRange = default, _failRange = default, _missRange = default;

    private void OnEnable()
    {
        InvokeRepeating("BrightenNote", 0f, 0.05f);
        _noteColor = Color.gray;
        _noteColor.a = 0;
        _line.color = _noteColor;
    }
    private void Start()
    {
        _isHit = false;
        _noteSprite = _circle.sprite;
        _orirect = Vector2.one * 200.0f;
        _effrect = Vector2.one * 300.0f;
    }

    private void OnDisable()
    {
        _lineSize = _line.rectTransform.sizeDelta = _setlineSize; // 초기 라인 사이즈로 복구
        _circle.sprite = _noteSprite; // 원래 노트 스프라이트로 복구
        _circle.rectTransform.sizeDelta = _orirect; // 원래 노트 사이즈로 변경
        _circle.raycastTarget = true; // 터치 감지 활성화
        _isHit = false;
    }

    private void Vibrate(long _millisec = 150)
    {
        Vibration.Vibrate(_millisec);
    }

    private void Hit(string _message)
    {
        _isHit = true;
        switch(_message) // 애니메이션 처리
        {
            case "AWESOME":
            case "GOOD":
                SetNote.instance.SetMotion(_motionName);
                ComboManager.instance.CreaseCombo();
                SoundManager.instance.PlaySFX(_sfxName);
                SetEdge.instance.SetEdgeImage(_motionName + "_EDGE");
                Vibrate();
                _circle.sprite = _effectSprite;
                _circle.rectTransform.sizeDelta = _effrect;
                break;
            case "FAIL":
            case "MISS":
                // 실패 애니메이션 진행 함수 작성
                SetEdge.instance.SetEdgeImage("FAIL_" + (SetNote.instance.SetMotion(_motionName, true) % 4).ToString() + "_EDGE");
                ComboManager.instance.ResetCombo();
                break;
        }
        _circle.raycastTarget = false; // 터치 감지 비활성화
        JudgeManager.instance.SetJudgeImage(_message); // 판정
        _motionName = "";
        if (IsInvoking("BrightenNote")) // 노트 생성 Invoke 해제
            CancelInvoke("BrightenNote");

        _line.color = Color.clear;
        InvokeRepeating("DarkenNote", 0f, 0.05f); 
    }

    private void BrightenNote()
    {
        _noteColor.a = Mathf.Clamp(_noteColor.a + 0.1f, 0f, 1f);
        _circle.color = _noteColor;
        _line.color = _noteColor;

        if (_line.rectTransform.sizeDelta.x - _circle.rectTransform.sizeDelta.x < _failRange + 1.0f) // Fail 판정시 Note가 밝아지지 않은 경우도 있기 때문에 미세한 값 수정
        {
            _circle.color = _line.color = _noteColor = Color.white;
            CancelInvoke();
        }
    }
    private void DarkenNote()
    { 
        _circle.color = _noteColor;
        _noteColor.a -= 0.1f; // 노트가 사라지는 상수값
        if(_noteColor.a <= 0f) // 노트가 투명해지면 비활성화
        {
            CancelInvoke();
            NotePoolingManager.instance.InsertNote(this, _notenane);
        }
    }
    
    public void InputAnimation(string _motion)
    {
        _motionName = _motion;
    }

    public void SetNoteProperties(float _linedistance, float _reduceValue, bool _isAuto = false)
    {
        Vector2 _lineValue;
        _lineValue.x = _lineValue.y = _linedistance;
        _lineSize = _setlineSize = _line.rectTransform.sizeDelta = _circle.rectTransform.sizeDelta + _lineValue;
        this._reduceValue = _reduceValue;
        this._isAuto = _isAuto;
    }

    public void InputSfxName(string _sfxName)
    {
        this._sfxName = _sfxName;
    }

    private void FixedUpdate()
    {
        if (!_isHit) // 판정선 축소
        {
            _lineSize.x -= _reduceValue * Time.deltaTime;
            _lineSize.y -= _reduceValue * Time.deltaTime;
            _line.rectTransform.sizeDelta = _lineSize;

            #region AUTOMODE
            if(_isAuto)
            {
                _judgeValue = _line.rectTransform.sizeDelta.x - _circle.rectTransform.sizeDelta.x;

                if (_judgeValue < _awesomeRange)
                {
                    Hit("AWESOME");
                    return;
                }
            }
            #endregion
            if (_line.rectTransform.sizeDelta.x < _circle.rectTransform.sizeDelta.x - _missRange) // 노트를 놓치는 판정 범위
                Hit("MISS");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_isHit)
        {
            _judgeValue = _line.rectTransform.sizeDelta.x - _circle.rectTransform.sizeDelta.x;
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
