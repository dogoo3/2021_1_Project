using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePoolingManager : MonoBehaviour
{
    public static NotePoolingManager instance;

    [SerializeField] private ShortNote _shortNote = default;
    [SerializeField] private LongNote[] _longNotes = default;
    [SerializeField] private SkullNote[] _skullNotes = default;
    // 저장 큐
    private Queue<ShortNote> _queue_shortNote = new Queue<ShortNote>();
    private Dictionary<string, Queue<LongNote>> _dic_longNote = new Dictionary<string, Queue<LongNote>>(); // 롱노트 프리팹의 개수에 맞게 배열로 선언

    // 활성화 큐
    private List<ShortNote> _activeShortNote = new List<ShortNote>();
    private List<LongNote> _activeLongNote = new List<LongNote>();

    private int i;
    private string[] value;

    private void Awake()
    {
        instance = this;

        value = FileManager.ReadTextOneLine(PlayMusicInfo.ReturnSongName() + ".txt", "Notes/").Split('/');
    }

    private void Start()
    {
        for (i = 0; i < 16; i++)
            Init(_shortNote, _queue_shortNote, "ShortNote", i);
        for (i = 0; i < _longNotes.Length; i++)
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

        temp.SetNoteProperties(float.Parse(value[0]), float.Parse(value[1]), PlayMusicInfo.ReturnAutoMode()); // 판정선거리, 감소속도
        temp.transform.SetParent(gameObject.transform, false);
        temp.name = _objName + "(" + turnNum.ToString() + ")";
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

    public void ResetNote()
    {
        for (int i = 0; i < _activeShortNote.Count; i++)
            InsertNote(_activeShortNote[i]);
        for (int i = 0; i < _activeLongNote.Count; i++)
            InsertNote(_activeLongNote[i]);
    }

    public void InsertNote(ShortNote _obj)
    {
        _obj.gameObject.SetActive(false);
        _queue_shortNote.Enqueue(_obj);
        _activeShortNote.Remove(_obj);
    }

    public void InsertNote(LongNote _obj)
    {
        _obj.gameObject.SetActive(false);
        _dic_longNote[_obj.GetNoteName()].Enqueue(_obj);
        _activeLongNote.Remove(_obj);
    }

    public void GetNote(Vector2 _origin, string _noteName, string _sfxName, string _motion = null)
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
