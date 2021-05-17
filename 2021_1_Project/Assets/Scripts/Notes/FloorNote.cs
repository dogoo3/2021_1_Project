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
    [Header("노트 이름")]
    [SerializeField] private string _notename = default;

    private Vector2 _notesize, _maxnotesize;
    private bool _isHit;
    private float _sizeratio, _judgeValue; // 너비와 높이의 비율
    [Header("판정선 축소 속도")]
    [SerializeField] private float _reduceValue = 300f;
    [Header("판정 범위")]
    [SerializeField] private float _awesomeRange = default, _goodRange = default, _failRange = default, _missRange = default;

    private void Awake()
    {
        _noteImage = GetComponent<Image>();
        _maxnotesize = _noteImage.rectTransform.sizeDelta;
        _sizeratio = _maxnotesize.x / _maxnotesize.y; // 최대 사이즈 노트의 비율을 구한다
    }

    private void OnEnable()
    {
    }

    private void FixedUpdate()
    {
        if(!_isHit)
        {
            _notesize.y += _reduceValue * Time.deltaTime;
            _notesize.x = _notesize.y * _sizeratio;

            if(_notesize.x <= _maxnotesize.x)
                _noteImage.rectTransform.sizeDelta = _notesize;

            if (_notesize.x > _maxnotesize.x + _missRange)
                Hit("MISS");
        }
    }

    private void OnDisable()
    {
        _isHit = false;
        _noteImage.rectTransform.sizeDelta = _notesize = Vector2.zero;
    }

    private void Hit(string _message)
    {
        switch(_message)
        {
            case "AWESOME":
            case "GOOD":
                Debug.Log(_message);
                break;
            case "FAIL":
            case "MISS":
                Debug.Log(_message);
                break;
        }
        _isHit = true;
        _noteImage.gameObject.SetActive(false);
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
