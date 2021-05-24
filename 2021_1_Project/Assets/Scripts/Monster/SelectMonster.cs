using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectMonster : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _monsterType = default;

    private Image _image;

    private float _lerpValue;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayMusicInfo.AppendMusicInfo(_monsterType);
        SetNote.instance.ReadNoteFile();
        NotePoolingManager.instance.ReadNoteFile();
        MonsterManager.instance.ChoiceMonster(_monsterType);
        MonsterManager.instance.StartMusic();
        _image.raycastTarget = false;
    }

    public void NonSelect()
    {
        _image.raycastTarget = false;
    }
}
