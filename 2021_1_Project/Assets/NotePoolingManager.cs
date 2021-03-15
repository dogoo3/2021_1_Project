using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePoolingManager : MonoBehaviour
{
    public static NotePoolingManager instance;

    [SerializeField] private GameObject[] _notePrefab;
    
    private void Awake()
    {
        instance = this;
    }
}
