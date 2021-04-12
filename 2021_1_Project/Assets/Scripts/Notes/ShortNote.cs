using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShortNote : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image _circle = default, _line = default;

    private bool _isHit, _isAuto; // 노트 터치 여부

    private float _judgeValue; // 판정 범위를 저장할 변수, 판정선과 노트의 범위 저장 변수

    private string _motionName = ""; // 정상 판정시 수행할 캐릭터 애니메이션 변수

    private Vector2 _lineSize, _setlineSize; // 변동시킬 판정선 사이즈, 복구시킬 판정선 사이즈

    private Color _noteColor;

    [Header("판정선 축소 속도")]
    [SerializeField] private float _reduceValue = 250.0f;
    [Header("판정 범위")]
    [SerializeField] private float _awesomeRange = default, _goodRange = default, _failRange = default, _missRange = default;

    private float _t;

    private void OnEnable()
    {
        InvokeRepeating("BrightenNote", 0f, 0.05f);
        _circle.raycastTarget = true;
        _noteColor = Color.gray;
        _noteColor.a = 0;
        _t = Time.time;
    }
    private void Start()
    {
        _isHit = false;
    }

    private void OnDisable()
    {
        _lineSize = _line.rectTransform.sizeDelta = _setlineSize; // 초기 라인 사이즈로 복구
        _isHit = false;
    }

    private void Hit(string _message)
    {
        _isHit = true;
        _circle.raycastTarget = false;
        switch(_message) // 애니메이션 처리
        {
            case "AWESOME":
            case "GOOD":
                SetNote.instance.SetMotion(_motionName);
                ComboManager.instance.CreaseCombo();
                break;
            case "FAIL":
            case "MISS":
                // 실패 애니메이션 진행 함수 작성
                SetNote.instance.SetMotion(_motionName, true);
                ComboManager.instance.ResetCombo();
                break;
        }
        JudgeManager.instance.SetJudgeImage(_message); // 판정
        _motionName = "";
        if (IsInvoking("BrightenNote")) // 노트 생성 Invoke 해제
            CancelInvoke("BrightenNote");

        InvokeRepeating("DarkenNote", 0f, 0.05f); 
    }

    private void BrightenNote()
    {
        _noteColor.a += 0.1f; // 노트가 보여지는 상수값
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
        _noteColor.a -= 0.1f; // 노트가 사라지는 상수값
        _circle.color = _noteColor;
        _line.color = _noteColor;
        if(_noteColor.a <= 0f) // 노트가 투명해지면 비활성화
        {
            CancelInvoke();
            NotePoolingManager.instance.InsertNote(this);
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
                    Hit("AWESOME");

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
