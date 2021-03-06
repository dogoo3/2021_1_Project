using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongNoteStopover : MonoBehaviour
{
    private Image _image;

    [Header("다음 경유지 노트")]
    [SerializeField] private LongNoteStopover _nextStopover = default;

    private bool _isSpread;

    private float _fillAmount, _movedepartcircle;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    private void Start()
    {
        _fillAmount = 1 / _image.rectTransform.sizeDelta.x;
    }

    private void Update()
    {
        if(_isSpread)
        {
            _image.fillAmount += _movedepartcircle * Time.deltaTime * _fillAmount;
            if(_image.fillAmount == 1.0f)
            {
                if(_nextStopover != null)
                    _nextStopover.SpreadNote(_movedepartcircle);
                _isSpread = false;
                _image.fillOrigin = 0; // LEFT 
            }
        }
    }

    public void SpreadNote(float _movedepartcircle)
    {
        this._movedepartcircle = _movedepartcircle;
        _isSpread = true;
    }

    public float SetFillAmount(Vector3 _departNotePos)
    {
        _image.fillAmount = Mathf.Abs(_departNotePos.x - transform.position.x) * _fillAmount;
        return _image.fillAmount;
    }

    public void SetFillAmount(float _value)
    {
        _image.fillAmount = _value;
    }

    public void ResetFillOrigin()
    {
        _image.fillOrigin = 1;
    }
}
