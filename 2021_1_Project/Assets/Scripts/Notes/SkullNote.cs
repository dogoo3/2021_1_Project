using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkullNote : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform _arrivePos = default;
    [SerializeField] private string _motionName = default;

    private Image _image;
    private Color _color;

    private Vector2 _departPos, _resetPos;

    private float _lerpValue, _time;
    private bool _isMove;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _color = Color.white;
        _departPos = _resetPos = transform.position;
    }
    private void OnEnable()
    {
        _departPos = _resetPos;
        _lerpValue = 0;
        _time = 0;
    }

    private void FAIL()
    {
        // 공격 모션 변환
        SetNote.instance.SetMotion("", true);
        transform.position = _arrivePos.position;
        InvokeRepeating("Transparent", 0f, 0.05f);
    }

    private void Success()
    {
        SetNote.instance.SetMotion(_motionName);
        gameObject.SetActive(false);
    }

    private void Transparent()
    {
        _color.a -= 0.1f;
        _image.color = _color;
        if (_color.a <= 0f)
        {
            CancelInvoke("Transparent");
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if(_isMove)
        {
            _time += Time.deltaTime;
            transform.position = Vector2.Lerp(_departPos, _arrivePos.position, _lerpValue);
            _lerpValue += 600 * 0.000033f;

            if (transform.position == _arrivePos.position)
            {
                FAIL();
                _isMove = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_isMove)
        {
            if (Vector2.Distance(_arrivePos.position, transform.position) > 30.0f) // 실패
                FAIL();
            else // 성공
                Success();
            _isMove = false;
        }
    }

    public void FailActive()
    {
        // 공격 모션 표현
        _isMove = false;
        transform.position = _arrivePos.position;
        gameObject.SetActive(true);
        InvokeRepeating("Transparent", 0f, 0.05f);
    }

    private void OnDisable()
    {
        transform.position = _departPos;
        _color = _image.color = Color.white;
    }
}
