using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkullNote : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform _arrivePos = default;
    [SerializeField] private string _motionName = default;

    private Animator _animator;

    private Image _image;
    private Color _color;

    private Vector2 _departPos, _resetPos;

    private float _lerpValue;
    private bool _isMove = true;
    private string _sfxName;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _animator = GetComponent<Animator>();
        _color = Color.white;
        _departPos = _resetPos = transform.position;
    }
    private void OnEnable()
    {
        _isMove = true;
        _departPos = _resetPos;
        _lerpValue = 0;
    }

    private void Vibrate(long _millisec = 150)
    {
        Vibration.Vibrate(_millisec);
    }
    
    private void SetMonsterGauge(string _message)
    {
        if (MonsterManager.instance != null)
            MonsterManager.instance.CarculateGauge(_message);
    }

    private void FAIL(string _message)
    {
        // 공격 모션 변환
        _animator.SetTrigger("attack");
        // 사운드 재생
        SetEdge.instance.SetEdgeImage("FAIL_" + SetNote.instance.SetMotion(_motionName, true).ToString() + "_EDGE");
        transform.position = _arrivePos.position;
        InvokeRepeating("Transparent", 0f, 0.05f);
        ComboManager.instance.ResetCombo();
        JudgeManager.instance.SetJudgeImage(_message); // 판정
        SetMonsterGauge("FAIL");
    }

    private void Success()
    {
        SetNote.instance.SetMotion(_motionName);
        SoundManager.instance.PlaySFX(_sfxName);
        SetEdge.instance.SetEdgeImage(_motionName + "_EDGE");
        ComboManager.instance.CreaseCombo();
        JudgeManager.instance.SetJudgeImage("AWESOME"); // 판정
        Vibrate();
        SetMonsterGauge("AWESOME");
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
            if (Vector2.Distance(_arrivePos.position, transform.position) > 180f) // 실패
                FAIL("FAIL");
            else // 성공
                Success();
            _isMove = false;
        }
    }

    public void FailActive() // 모션만 부활시켜놓는 함수
    {
        // 공격 모션 표현
        gameObject.SetActive(true);
        _animator.SetTrigger("attack");
        transform.position = _arrivePos.position;
        _isMove = false;
        InvokeRepeating("Transparent", 0f, 0.05f);
    }

    public void ActiveNote(string _sfxName)
    {
        this._sfxName = _sfxName;
        gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        transform.position = _departPos;
        _color = _image.color = Color.white;
    }
}
