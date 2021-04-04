using UnityEngine;
using System.Collections;
using System;

public class LongNote : MonoBehaviour
{
    [Header("롱노트 이름")]
    [SerializeField] private string _noteName = default;

    [SerializeField] private LongNoteDepart _departNote;

    private void Awake()
    {
        _departNote = GetComponentInChildren<LongNoteDepart>();
    }
    public string GetNoteName()
    {
        return _noteName;
    }

    public void SetNoteProperties(float _linedistance, float _reduceValue, float _notemovespeed = 700.0f, bool _isAuto = false)
    {
        _departNote.SetNoteProperties(_linedistance, _reduceValue, _notemovespeed, _isAuto);
    }

    public void InputAnimation(string _animation)
    {
        _departNote.InputAnimation(_animation);
    }
}
