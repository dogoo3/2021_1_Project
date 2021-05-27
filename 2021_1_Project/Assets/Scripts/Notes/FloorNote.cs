using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class FloorNote : MonoBehaviour, IPointerDownHandler
{
    private Image _noteImage;

    [Header("성공시 이펙트 이미지")]
    [SerializeField] private Sprite _effectSprite = default;

    private Sprite _oriSprite;
    private Color _noteColor = Color.white;

    private Vector2 _notesize, _maxnotesize;
    private Vector2 _orirect { get { return new Vector2(440.0f, 130.0f); } }
    private Vector2 _effrect { get { return Vector2.one * 300.0f; } }

    private bool _isHit;
    private float _sizeratio, _judgeValue; // 너비와 높이의 비율
    private string _sfxName = "", _motionName = "";

    [Header("판정선 축소 속도")]
    [SerializeField] private float _reduceValue = 300.0f;
    [Header("판정 범위")]
    [SerializeField] private float _awesomeRange = default, _goodRange = default, _failRange = default, _missRange = default;
    
    private void Awake()
    {
        _noteImage = GetComponent<Image>();
        _oriSprite = _noteImage.sprite;
        _maxnotesize = _orirect;
        _sizeratio = _maxnotesize.x / _maxnotesize.y; // 최대 사이즈 노트의 비율을 구한다
    }

    private void OnEnable()
    {
        _noteImage.color = Color.white;
    }

    private void FixedUpdate()
    {
        if(!_isHit)
        {
            _notesize.y += _reduceValue * Time.deltaTime; // 일정 값만큼 y를 늘리고
            _notesize.x = _notesize.y * _sizeratio; // 그 y의 비례한 값만큼 x를 늘린다

            if(_notesize.x <= _maxnotesize.x)
                _noteImage.rectTransform.sizeDelta = _notesize;

            #region AUTOMODE
            if(PlayMusicInfo.ReturnAutoMode())
            {
                if (_notesize.x >= _maxnotesize.x)
                    Hit("AWESOME");
            }
            else
            {
                if (_notesize.x > _maxnotesize.x + _missRange)
                    Hit("MISS");
            }
            #endregion
        }
    }

    private void OnDisable()
    {
        _isHit = false;
        _noteImage.rectTransform.sizeDelta = _notesize = Vector2.zero;
        _noteImage.sprite = _oriSprite;
        _noteColor = Color.white;
    }

    private void Hit(string _message)
    {
        switch(_message)
        {
            case "AWESOME":
            case "GOOD":
                SetNote.instance.SetMotion(_motionName);
                ComboManager.instance.CreaseCombo();
                SoundManager.instance.PlaySFX(_sfxName);
                SetEdge.instance.SetEdgeImage(_motionName + "_EDGE");
                Vibrate();
                _noteImage.rectTransform.sizeDelta = _effrect;
                _noteImage.sprite = _effectSprite;
                break;
            case "FAIL":
            case "MISS":
                SetEdge.instance.SetEdgeImage("FAIL_" + (SetNote.instance.SetMotion(_motionName, true) % 4).ToString() + "_EDGE");
                ComboManager.instance.ResetCombo();
                break;
        }
        JudgeManager.instance.SetJudgeImage(_message);
        SetMonsterGauge(_message);
        _motionName = "";
        InvokeRepeating("DarkenNote", 0f, 0.05f);
        _isHit = true;
    }

    private void SetMonsterGauge(string _message)
    {
        if (MonsterManager.instance != null)
            MonsterManager.instance.CarculateGauge(_message);
    }

    private void DarkenNote()
    {
        _noteColor.a -= 0.1f;
        _noteImage.color = _noteColor;

        if(_noteColor.a <= 0f)
        {
            CancelInvoke();
            gameObject.SetActive(false);
        }
    }
    
    private void Vibrate(long _millisec = 150)
    {
        Vibration.Vibrate(_millisec);
    }
     
    public void ActiveNote(string _sfxName, string _motionName)
    {
        this._sfxName = _sfxName;
        this._motionName = _motionName;
        Invoke("Active", 0.42f);
    }

    private void Active()
    {
        gameObject.SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _judgeValue = Mathf.Abs(_maxnotesize.x - _notesize.x);
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
