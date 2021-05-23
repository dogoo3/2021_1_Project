using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectMonster : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _monsterType = default;
    [SerializeField] private Transform _arrivePos = default;

    private Image _image;
    private Color _color = Color.white;

    private Vector2 _departPos;

    private bool _isSelect, _isNonselect;
    private float _lerpValue;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _departPos = transform.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayMusicInfo.AppendMusicInfo(_monsterType);
        SetNote.instance.ReadNoteFile();
        NotePoolingManager.instance.ReadNoteFile();
        MonsterManager.instance.ChoiceMonster(_monsterType);
        _image.raycastTarget = false;
        _isSelect = true;
    }

    private void Update()
    {
        if(_isSelect) // 몬스터가 선택되었을 때
        {
            _color.a -= 0.04f;
            _image.color = _color;
            if (_image.color.a <= 0f)
                _isSelect = false;
        }
        if(_isNonselect) // 몬스터가 선택되지 않았을 때
        {
            _lerpValue += 0.04f;
            transform.position = Vector2.Lerp(_departPos, _arrivePos.position, _lerpValue); 
            if(_lerpValue >= 1.0f)
            {
                _isNonselect = false;
            }
        }
    }

    public void NonSelect()
    {
        _image.raycastTarget = false;
        _isNonselect = true;
    }
}
