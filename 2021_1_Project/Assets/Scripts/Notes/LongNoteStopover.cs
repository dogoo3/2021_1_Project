using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongNoteStopover : MonoBehaviour
{
    private Image _image;

    [Header("다음 경유지 노트")]
    [SerializeField] private LongNoteStopover _nextStopover = default;
    [Header("중간 경유 포인트의 이미지들, 도착노트에 적용")]
    [SerializeField] private Image[] _pointImage = default;

    private Color _color;
    private bool _isSpread;

    private float _fillAmount, _movedepartcircle;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    private void Start()
    {
        _fillAmount = 1 / _image.rectTransform.sizeDelta.x;
        _color = Color.white;
        _color.a = 0f;
    }


    private void FixedUpdate()
    {
        if(_isSpread)
        {
            _image.fillAmount += _movedepartcircle * Time.deltaTime * _fillAmount;
            if(_image.fillAmount >= 1.0f) // 현재 오브젝트가 다 펼쳐졌으면
            {
                if (_nextStopover != null) // 다음 경유지 체크 후 
                    _nextStopover.SpreadNote(_movedepartcircle); // 다음 경유지 노트를 펼쳐줌
                else // 다음 경유지가 없으면(도착노트이면)
                    InvokeRepeating("ActivePointImage", 0f, 0.05f); // 중간 포인트 노트 이미지를 활성화해줌.

                _image.fillOrigin = 0; // LEFT 
                //SetFillOrigin();
                _isSpread = false; // 현재 오브젝트의 fillAmount 조정해제
            }
        }
    }

    private void OnDisable()
    {
        _color = Color.white;
        _color.a = 0f;
        if(IsInvoking("ActivePointImage"))
            CancelInvoke("ActivePointImage");
        for (int i = 0; i < _pointImage.Length; i++)
            _pointImage[i].color = _color;
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
        //SetFillOrigin();
        _image.fillAmount = 0;
        _movedepartcircle = 0;
        _isSpread = false;
    }

    public void SetColor(Color _color) // 색상 및 투명도 조절 시 사용
    {
        _image.color = _color;
    }

    public void SetColor(int _index) // 포인트 노트 이미지 투명화 시 사용
    {
        _pointImage[_index].color = Color.clear;
    }

    private void SetFillOrigin()
    {
        if (_image.fillOrigin == 1)
            _image.fillOrigin = 0;
        else
            _image.fillOrigin = 1;
    }

    private void ActivePointImage()
    {
        _color.a += 0.1f;
        for (int i=0;i<_pointImage.Length;i++)
            _pointImage[i].color = _color;
        if (_color.a >= 1)
            CancelInvoke("ActivePointImage");
    }

    private void InActivePointImage()
    {
        _color.a -= 0.1f;
        for (int i = 0; i < _pointImage.Length; i++)
        {
            if (_pointImage[i].color.a != 0)
                _pointImage[i].color = _color;
        }
        if (_color.a <= 0)
            CancelInvoke("InActivePointImage");
    }
}
