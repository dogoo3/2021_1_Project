using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNote : MonoBehaviour
{
    private List<string> _noteInfo = new List<string>();
    private List<Note> _note = new List<Note>();

    private string[] _getInfo;

    private bool _isStart = false;

    private int _index = 0, _afterIndex, _upIndex = 0;

    private float _startTime;

    private void Awake()
    {
        _noteInfo = FileManager.ReadFile_TXT("evans.txt", "Notes/");
        
        for(int i=0;i<_noteInfo.Count;i++)
        {
            _getInfo = _noteInfo[i].Split('/');
            if (_getInfo.Length == 3)
                _note.Add(new Note(float.Parse(_getInfo[0]), _getInfo[1], _getInfo[2]));
            else
                _note.Add(new Note(float.Parse(_getInfo[0]), _getInfo[1], _getInfo[2], _getInfo[3]));
        }

        Invoke("StartMusic", 5.0f);
    }

    private void StartMusic()
    {
        _startTime = Time.time;
        _isStart = true;
        SoundManager.instance.Play();
    }

    private void FixedUpdate()
    {
        if (_isStart)
        {
            for (int i = _index; i < Mathf.Clamp(_index + 3, 0, _note.Count); i++)
            {
                if(_note[i].activeTime <= Time.time - _startTime)
                {
                    Debug.Log(Time.time - _startTime);
                    _upIndex++;
                }
            }

            _index += _upIndex;
            _upIndex = 0;
            if(_index >= _note.Count)
            {
                Debug.Log("노트끝");
                _isStart = false;
            }
            //if (_note[_index].activeTime <= Time.time - _startTime)
            //{
            //    Debug.Log(Time.time - _startTime + " / " + _note[_index].notename + " / " + _note[_index].joint);
            //    _index++;
            //}
            //if (_note.Count <= _index)
            //{
            //    Debug.Log("노트끝");
            //    _isStart = false;
            //}
        }
    }
}
