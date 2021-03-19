﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePoolingManager : MonoBehaviour
{
    public static NotePoolingManager instance;

    [SerializeField] private ShortNote _shortNote = default;
    [SerializeField] private LongNote[] _longNotes = default;

    // 저장 큐
    private Queue<ShortNote> _queue_shortNote = new Queue<ShortNote>();
    private Dictionary<string, Queue<LongNote>> _dic_longNote = new Dictionary<string, Queue<LongNote>>(); // 롱노트 프리팹의 개수에 맞게 배열로 선언

    private int i;

    private void Awake()
    {
        instance = this;

        for (i = 0; i < 8; i++)
            Init(_shortNote, _queue_shortNote, "ShortNote", i);
        for(i=0;i< _longNotes.Length;i++)
        {
            Queue<LongNote> longNotes = new Queue<LongNote>(); // 딕셔너리 안에 들어갈 큐 할당
            for (int j = 0; j < 3; j++)
                Init(_longNotes[i], longNotes, "LongNote" + i.ToString(), i); // 큐 안에 자료 삽입
            _dic_longNote.Add("LongNote" + i.ToString(), longNotes); // 딕셔너리 안에 자료 삽입
            longNotes = null;
        }
    }

    private void Init(ShortNote _prefab, Queue<ShortNote> _inputQueue, string _objName, int turnNum)
    {
        ShortNote temp = Instantiate(_prefab, Vector2.zero, Quaternion.identity);
        temp.transform.SetParent(gameObject.transform, false);
        temp.name = _objName + "(" + turnNum.ToString() + ")";
        _inputQueue.Enqueue(temp);
    }

    private void Init(LongNote _prefab, Queue<LongNote> _inputQueue, string _objName, int turnNum)
    {
        LongNote temp = Instantiate(_prefab, Vector2.zero, Quaternion.identity);
        temp.transform.SetParent(gameObject.transform, false);
        temp.name = _objName + "(" + turnNum.ToString() + ")";
        _inputQueue.Enqueue(temp);
    }

    public void InsertNote(ShortNote _obj)
    {
        _obj.gameObject.SetActive(false);
        _queue_shortNote.Enqueue(_obj);
    }

    public void InsertNote(LongNote _obj)
    {
        _obj.gameObject.SetActive(false);
        _dic_longNote[_obj.GetNoteName()].Enqueue(_obj);
    }

    public void GetNote(Vector2 _origin, string _noteName)
    {
        if (_noteName == "ShortNote")
        {
            if (_queue_shortNote.Count > 0)
            {
                ShortNote _temp = _queue_shortNote.Dequeue();
                _temp.transform.position = _origin;
                _temp.gameObject.SetActive(true);
            }
        }
        else
        {
            if (_dic_longNote[_noteName].Count > 0)
            {
                LongNote _temp = _dic_longNote[_noteName].Dequeue();
                _temp.gameObject.SetActive(true);
            }
        }
    }
}