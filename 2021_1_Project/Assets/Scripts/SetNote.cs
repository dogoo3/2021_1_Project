using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNote : MonoBehaviour
{
    public static SetNote instance;

    private Animator _animator;

    [SerializeField] private Transform[] _joints = default;

    private List<string> _noteInfo = new List<string>();
    private List<Note> _note = new List<Note>();
    private Dictionary<string, Transform> _jointPoints = new Dictionary<string, Transform>();

    private string[] _getInfo;

    private bool _isStart = false;

    private int _index = 0, _afterIndex, _upIndex = 0;

    private float _startTime, _songDelay = 1.2f;
    
    private void Awake()
    {
        instance = this;

        _animator = GetComponent<Animator>();

        Debug.Log(_animator.runtimeAnimatorController.animationClips[0]); // 애니메이션 가져오는 방법
        Debug.Log(_animator.runtimeAnimatorController.animationClips[0].frameRate); // 애니메이션의 프레임 가져오는 방법
        Debug.Log(_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name); // 현재 재생중인 애니메이션 가져오는 방법
        _animator.Play("motion1", 0, 0.25f); // 애니메이션 재생
        // _animator.Play("Idle", 0, 0.75f);
        _noteInfo = FileManager.ReadFile_TXT(PlayMusicInfo.ReturnSongName() + ".txt", "Notes/");

        if (_noteInfo != null)
        {
            for (int i = 0; i < _noteInfo.Count; i++)
            {
                _getInfo = _noteInfo[i].Split('/');
                if (_getInfo.Length == 3)
                    _note.Add(new Note(float.Parse(_getInfo[0]), _getInfo[1], _getInfo[2]));
                else
                    _note.Add(new Note(float.Parse(_getInfo[0]), _getInfo[1], _getInfo[2], _getInfo[3]));
            }

            Invoke("StartMusic", 5.0f);
        }

        _jointPoints.Add("Lshoulder", _joints[0]);
        _jointPoints.Add("Rshoulder", _joints[1]);
        _jointPoints.Add("Lhand", _joints[2]);
        _jointPoints.Add("Rhand", _joints[3]);
        _jointPoints.Add("Lknee", _joints[4]);
        _jointPoints.Add("Rknee", _joints[5]);
        _jointPoints.Add("Lfoot", _joints[6]);
        _jointPoints.Add("Rfoot", _joints[7]);
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
                if(_note[i].activeTime - _songDelay <= Time.time - _startTime)
                {
                    // 노트 출력
                    NotePoolingManager.instance.GetNote(_jointPoints[_note[i].joint].position, _note[i].notename, _note[i].animation);
                        // SetAnimation();
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
        }
    }

    public void SetAnimation(string animation)
    {
        if (animation == "")
            return;
        for(int i=0;i<_animator.parameterCount;i++)
        {
            if (animation == _animator.parameters[i].name)
                _animator.SetBool(animation, true);
            else
                _animator.SetBool(_animator.parameters[i].name, false);
        }
    }
}
