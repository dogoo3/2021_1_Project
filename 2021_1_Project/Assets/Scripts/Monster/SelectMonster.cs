using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectMonster : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _monsterType = default;
    [SerializeField] private MonsterSmoke _smoke = default;

    private Animator _animator;

    private Image _image;

    private float _lerpValue;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _smoke.Enable();
    }

    private void OnDisable()
    {
        _smoke.Enable();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayMusicInfo.AppendMusicInfo(_monsterType);
        SetNote.instance.ReadNoteFile();
        NotePoolingManager.instance.ReadNoteFile();
        MonsterManager.instance.ChoiceMonster(_monsterType);
        MonsterManager.instance.StartMusic();
        _animator.enabled = false;
        _image.raycastTarget = false;
    }

    public void NonSelect()
    {
        _image.raycastTarget = false;
        _animator.enabled = false;
    }

    public string GetMotionName()
    {
        return _image.sprite.name;
    }

    public void SetMotion(Sprite _motion)
    {
        _image.sprite = _motion;
    }
}
