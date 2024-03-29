﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePoolingManager : MonoBehaviour
{
    public static NotePoolingManager instance;

    [SerializeField] private ShortNote _shortNote = default;
    [SerializeField] private ShortNote _multiShortNote = default;
    [SerializeField] private LongNote[] _longNotes = default;
    [SerializeField] private SkullNote[] _skullNotes = default;
    [SerializeField] private SlashNote[] _slashNotes = default;
    [SerializeField] private FloorNote[] _floorNotes = default;

    [Header("씬이 넘어오자마자 음악이 바로 재생되는가?")]
    [SerializeField] private bool _isNowStart = true;

    // 저장 큐
    private Queue<ShortNote> _queue_shortNote = new Queue<ShortNote>();
    private Queue<ShortNote> _queue_multiShortNote = new Queue<ShortNote>();
    private Dictionary<string, Queue<LongNote>> _dic_longNote = new Dictionary<string, Queue<LongNote>>(); // 롱노트 프리팹의 개수에 맞게 배열로 선언
    private Dictionary<string, Queue<SlashNote>> _dic_slashNote = new Dictionary<string, Queue<SlashNote>>(); // 슬래시 노트 프리팹의 개수에 맞게 배열로 선언

    // 활성화 큐
    private List<ShortNote> _activeShortNote = new List<ShortNote>();
    private List<ShortNote> _activeMultiShortNote = new List<ShortNote>();
    private List<LongNote> _activeLongNote = new List<LongNote>();
    private List<SlashNote> _activeSlashNote = new List<SlashNote>();

    private int i;
    private string[] value;

    private void Awake()
    {
        instance = this;
        if (_isNowStart)
            ReadNoteFile();
    }

    public void ReadNoteFile()
    {
        value = FileManager.ReadTextOneLine(PlayMusicInfo.ReturnSongName() + ".txt", "Notes/").Split('/');
        MakeObjectPool();
    }

    private void MakeObjectPool()
    {
        for (i = 0; i < 16; i++)
        {
            Init(_shortNote, _queue_shortNote, "ShortNote", i);
            Init(_multiShortNote, _queue_multiShortNote, "MultiShortNote", i);
        }

        for (i = 0; i < _longNotes.Length; i++) // 롱노트 생성
        {
            Queue<LongNote> longNotes = new Queue<LongNote>(); // 딕셔너리 안에 들어갈 큐 할당
            for (int j = 0; j < 3; j++)
                Init(_longNotes[i], longNotes, _longNotes[i].GetNoteName(), j); // 큐 안에 자료 삽입
            _dic_longNote.Add(_longNotes[i].GetNoteName(), longNotes); // 딕셔너리 안에 자료 삽입
            longNotes = null;
        }

        if(_slashNotes != null)
        {
            for (i = 0; i < _slashNotes.Length; i++) // 슬래시 노트 생성
            {
                Queue<SlashNote> slashNotes = new Queue<SlashNote>(); // 딕셔너리 안에 들어갈 큐 할당
                for (int j = 0; j < 3; j++)
                    Init(_slashNotes[i], slashNotes, _slashNotes[i].GetNoteName(), j); // 큐 안에 자료 삽입
                _dic_slashNote.Add(_slashNotes[i].GetNoteName(), slashNotes); // 딕셔너리 안에 자료 삽입
                slashNotes = null;
            }
        }
    }

    private void Init(ShortNote _prefab, Queue<ShortNote> _inputQueue, string _objName, int turnNum)
    {
        ShortNote temp = Instantiate(_prefab, Vector2.zero, Quaternion.identity);

        temp.SetNoteProperties(float.Parse(value[0]), float.Parse(value[1]), PlayMusicInfo.ReturnAutoMode()); // 판정선거리, 감소속도
        temp.transform.SetParent(gameObject.transform, false);
        temp.name = _objName + " (" + turnNum.ToString() + ")";
        _inputQueue.Enqueue(temp);
    }

    private void Init(LongNote _prefab, Queue<LongNote> _inputQueue, string _objName, int turnNum)
    {
        LongNote temp = Instantiate(_prefab, Vector2.zero, Quaternion.identity);
        
        temp.SetNoteProperties(float.Parse(value[0]), float.Parse(value[1]), float.Parse(value[2]), PlayMusicInfo.ReturnAutoMode()); // 판정선거리, 감소속도
        temp.transform.SetParent(gameObject.transform, false);
        temp.name = _objName + "(" + turnNum.ToString() + ")";
        _inputQueue.Enqueue(temp);
    }

    private void Init(SlashNote _prefab, Queue<SlashNote> _inputQueue, string _objName, int turnNum)
    {
        SlashNote temp = Instantiate(_prefab, Vector2.zero, Quaternion.identity);

        temp.SetNoteProperties(float.Parse(value[0]), float.Parse(value[1]), PlayMusicInfo.ReturnAutoMode()); // 판정선거리, 감소속도
        temp.transform.SetParent(gameObject.transform, false);
        temp.name = _objName + "(" + turnNum.ToString() + ")";
        _inputQueue.Enqueue(temp);
    }

    public void ResetNote()
    {
        for (int i = 0; i < _activeShortNote.Count; i++)
        {
            _activeShortNote[i].gameObject.SetActive(false);
            _queue_shortNote.Enqueue(_activeShortNote[i]);
        }
        for (int i = 0; i < _activeLongNote.Count; i++)
        {
            _activeLongNote[i].gameObject.SetActive(false);
            _dic_longNote[_activeLongNote[i].GetNoteName()].Enqueue(_activeLongNote[i]);
        }
        for (int i = 0; i < _skullNotes.Length; i++)
        {
            if (_skullNotes[i].gameObject.activeSelf)
                _skullNotes[i].gameObject.SetActive(false);
        }
        for(int i=0;i<_activeMultiShortNote.Count;i++)
        {
            _activeMultiShortNote[i].gameObject.SetActive(false);
            _queue_multiShortNote.Enqueue(_activeMultiShortNote[i]);
        }
        _activeShortNote.Clear();
        _activeLongNote.Clear();
        _activeMultiShortNote.Clear();
    }

    public void InsertNote(ShortNote _obj, string _notename)
    {
        switch(_notename)
        {
            case "ShortNote":
                _queue_shortNote.Enqueue(_obj);
                _activeShortNote.Remove(_obj);
                break;
            case "MultiShortNote":
                _queue_multiShortNote.Enqueue(_obj);
                _activeMultiShortNote.Remove(_obj);
                break;
        }
        _obj.gameObject.SetActive(false);
    }

    public void InsertNote(LongNote _obj)
    {
        _obj.gameObject.SetActive(false);
        _dic_longNote[_obj.GetNoteName()].Enqueue(_obj);
        _activeLongNote.Remove(_obj);
    }

    public void InsertNote(SlashNote _obj)
    {
        _obj.gameObject.SetActive(false);
        _dic_slashNote[_obj.GetNoteName()].Enqueue(_obj);
        _activeSlashNote.Remove(_obj);
    }

    public void GetNote(Vector2 _origin, string _noteName, string _sfxName, string _motion = "")
    {
        if (_noteName == "ShortNote")
        {
            if (_queue_shortNote.Count > 0)
            {
                ShortNote _temp = _queue_shortNote.Dequeue();
                _temp.InputSfxName(_sfxName);
                if (_motion != null) // 다음에 변경될 모션을 가지고 있으면
                    _temp.InputAnimation(_motion); // 변경될 모션의 이름을 알려준다

                _temp.transform.position = _origin;

                _temp.gameObject.SetActive(true);
                _temp.gameObject.transform.SetAsFirstSibling();
                _activeShortNote.Add(_temp); // 활성화 노트 리스트에 넣어줌
            }
        }
        else if (_noteName.Substring(0, 6) == "LongNo")
        {
            if (_dic_longNote[_noteName].Count > 0)
            {
                LongNote _temp = _dic_longNote[_noteName].Dequeue();
                _temp.InputSfxName(_sfxName);
                if (_motion != null) // 다음에 변경될 모션을 가지고 있으면
                    _temp.InputAnimation(_motion); // 변경될 모션의 이름을 알려준다

                _temp.transform.position = _origin;

                _temp.gameObject.SetActive(true);
                _temp.gameObject.transform.SetAsFirstSibling();
                _activeLongNote.Add(_temp);
            }
        }
        else if(_noteName == "MultiShortNote")
        {
            if(_queue_multiShortNote.Count > 0)
            {
                ShortNote _temp = _queue_multiShortNote.Dequeue();
                _temp.InputSfxName(_sfxName);
                if (_motion != null) // 다음에 변경될 모션을 가지고 있으면
                    _temp.InputAnimation(_motion); // 변경될 모션의 이름을 알려준다

                _temp.transform.position = _origin;

                _temp.gameObject.SetActive(true);
                _temp.gameObject.transform.SetAsFirstSibling();
                _activeMultiShortNote.Add(_temp); // 활성화 노트 리스트에 넣어줌
            }
        }
        else if(_noteName.Substring(0,5) == "Slash")
        {
            if(_dic_slashNote[_noteName].Count != 0)
            {
                SlashNote _temp = _dic_slashNote[_noteName].Dequeue();
                _temp.InputSfxName(_sfxName);
                if (_motion != null) // 다음에 변경될 모션을 가지고 있으면
                    _temp.InputAnimation(_motion); // 변경될 모션의 이름을 알려준다

                _temp.transform.position = _origin;

                _temp.gameObject.SetActive(true);
                _temp.gameObject.transform.SetAsFirstSibling();
                _activeSlashNote.Add(_temp);
            }
        }
        else if(_noteName.Substring(0,5) == "Floor")
        {
            if (_noteName == "FloorNote_L")
                _floorNotes[0].ActiveNote(_sfxName, _motion);
            else
                _floorNotes[1].ActiveNote(_sfxName, _motion);
        }
        else
        {
            if (_noteName == "Skull_L")
                _skullNotes[0].ActiveNote(_sfxName);
            else
                _skullNotes[1].ActiveNote(_sfxName);
        }
    }

    public void GetFailSkullNote(string _noteName)
    {
        if (_noteName == "Skull_L")
            _skullNotes[0].FailActive();
        else
            _skullNotes[1].FailActive();
    }
}
