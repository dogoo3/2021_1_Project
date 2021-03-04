using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShortNote : MonoBehaviour, IPointerDownHandler
{
    public Text judgeText;

    private Image _circle;

    [SerializeField] private Image _line = default;

    private bool _isHit;

    public float _reduceValue = 250.0f;

    private Vector2 _lineSize, _setlineSize;

    private Color _noteColor;

    private void Awake()
    {
        _circle = GetComponent<Image>();
    }
    private void Start()
    {
        _circle.color = _noteColor;
        _line.color = _noteColor;
        
        _lineSize = _setlineSize = _line.rectTransform.sizeDelta; // 초기 판정선 크기 지정
        
        _isHit = false;
    }

    private void OnEnable()
    {
        InvokeRepeating("BrightenNote", 0f, 0.05f);
        judgeText.text = "";
        _noteColor = Color.gray;
        _noteColor.a = 0;
    }

    private void OnDisable()
    {
        _lineSize = _line.rectTransform.sizeDelta = _setlineSize;
        _isHit = false;
    }

    private void Hit(string _message)
    {
        _isHit = true;
        judgeText.text = _message;
        InvokeRepeating("DarkenNote", 0f, 0.05f);
    }

    private void BrightenNote()
    {
        _noteColor.a += 0.1f;
        _circle.color = _noteColor;
        _line.color = _noteColor;

        if(_line.rectTransform.sizeDelta.x - _circle.rectTransform.sizeDelta.x < 50.0f)
        {
            _noteColor = Color.white;

            _circle.color = _noteColor;
            _line.color = _noteColor;
            CancelInvoke();
        }
    }
    private void DarkenNote()
    {
        if(IsInvoking("BrightenNote"))
            CancelInvoke("BrightenNote");
        _noteColor.a -= 0.1f;
        _circle.color = _noteColor;
        _line.color = _noteColor;
        if(_noteColor.a <= 0f)
        {
            CancelInvoke();
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!_isHit)
        {
            _lineSize.x -= _reduceValue * Time.deltaTime;
            _lineSize.y -= _reduceValue * Time.deltaTime;
            _line.rectTransform.sizeDelta = _lineSize;
            if (_line.rectTransform.sizeDelta.x < _circle.rectTransform.sizeDelta.x - 10.0f)
                Hit("FAIL");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_isHit)
        {
            float _value = _line.rectTransform.sizeDelta.x - _circle.rectTransform.sizeDelta.x;

            if (_value < 20.0f)
                Hit("AWESOME");
            else if (_value < 30.0f)
                Hit("GOOD");
            else if (_value < 40.0f)
                Hit("BAD");
            else if (_value < 50.0f)
                Hit("FAIL");
            else { }
        }
    }


}
