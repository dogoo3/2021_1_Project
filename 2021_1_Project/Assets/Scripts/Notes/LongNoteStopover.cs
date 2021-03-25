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
            if(_image.fillAmount >= 1.0f) // 현재 오브젝트가 다 펼쳐졌으면
            {
                if (_nextStopover != null) // 다음 경유지 체크 후 
                {
                    _nextStopover.SpreadNote(_movedepartcircle); // 다음 경유지 노트를 펼쳐줌
                }

                _image.fillOrigin = 0; // LEFT 
                _isSpread = false; // 현재 오브젝트의 fillAmount 조정해제
            }
        }
    }

    public void SpreadNote(float _movedepartcircle) // 오브젝트의 펼쳐짐 허용 함수
    {
        this._movedepartcircle = _movedepartcircle;
        _isSpread = true;
    }

    public float SetFillAmount(Vector3 _departNotePos) // 출발 노트의 위치에 비례해 fillAmount를 조절하는 함수
    {
        _image.fillAmount = Vector3.Distance(_departNotePos, transform.position) * _fillAmount;
        return _image.fillAmount;
    }

    public void SetFillAmount(float _value) // 상수로 fillAmount 조정
    {
        _image.fillAmount = _value;
    }

    public void ResetFillOrigin() // 롱노트 비활성화시 초기화를 위한 함수
    {
        _image.fillOrigin = 1;
        _image.fillAmount = 0;
        _movedepartcircle = 0;
        _isSpread = false;
    }

    public void SetColor(Color _color) // 색상 및 투명도 조절 시 사용
    {
        _image.color = _color;
    }
}
