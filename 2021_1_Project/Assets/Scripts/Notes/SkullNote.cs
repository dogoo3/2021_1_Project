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

    private float _lerpValue;
    private bool _isMove = true;

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
    }

    private void FAIL(string _message)
    {
        // 공격 모션 변환
        // 사운드 재생
        SetNote.instance.SetMotion("", true);
        transform.position = _arrivePos.position;
        InvokeRepeating("Transparent", 0f, 0.05f);
        ComboManager.instance.ResetCombo();
        JudgeManager.instance.SetJudgeImage(_message); // 판정
    }

    private void Success()
    {
        SetNote.instance.SetMotion(_motionName);
        SetEdge.instance.SetEdgeImage(_motionName + "_EDGE");
        ComboManager.instance.CreaseCombo();
        JudgeManager.instance.SetJudgeImage("AWESOME"); // 판정
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
            transform.position = Vector2.Lerp(_departPos, _arrivePos.position, _lerpValue);
            _lerpValue += 300 * 0.000033f;

            if(PlayMusicInfo.ReturnAutoMode())
            {
                if (Vector2.Distance(_arrivePos.position, transform.position) < 50f)
                    Success();
            }
            if (transform.position == _arrivePos.position)
            {
                FAIL("MISS");
                _isMove = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_isMove)
        {
            if (Vector2.Distance(_arrivePos.position, transform.position) > 100f) // 실패
                FAIL("FAIL");
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
        _isMove = true;
    }
}
