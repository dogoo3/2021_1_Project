using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Song : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _image_jacket = default;
    [SerializeField] private Text _text_title = default, _text_composer = default;
    [SerializeField] private Image _level = default;

    private AudioClip _song;
    private float _highlightpos;
    private string _gameMode;

    public void SetValue(string[] _filenames)
    {
        _text_title.text = _filenames[0];
        _song = Resources.Load<AudioClip>("Sounds/Songs/" + _filenames[1]);
        _text_composer.text = _filenames[2];
        _image_jacket.sprite = Resources.Load<Sprite>("JacketImage/" + _filenames[3]);
        _highlightpos = float.Parse(_filenames[4]);
        _gameMode = _filenames[5];
        _level.fillAmount = float.Parse(_filenames[6]) * 0.2f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChoiceStageManager.instance.ChoiceSong(_song, _highlightpos, _gameMode);
    }
}
