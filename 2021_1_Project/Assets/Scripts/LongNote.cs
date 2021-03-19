using UnityEngine;
using System.Collections;

public class LongNote : MonoBehaviour
{
    [Header("롱노트 이름")]
    [SerializeField] private string _noteName = default;

    public string GetNoteName()
    {
        return _noteName;
    }
}
