﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNote : MonoBehaviour
{
    public static SetNote instance;

    private Animator _animator;

    [SerializeField] private GameClearManager _gameClearManager = default;
    [SerializeField] private Transform[] _joints = default;

    private List<string> _noteInfo = new List<string>();
    private List<Note> _note = new List<Note>();
    private Dictionary<string, Transform> _jointPoints = new Dictionary<string, Transform>();
    private Dictionary<string, int> _animationIndex = new Dictionary<string, int>();
    private string[] _getInfo;

    private bool _isStart = false;

    private int _index = 0, _afterIndex, _upIndex = 0, _aniIndex = 0, _failIndex = 0;

    private float _startTime, _songDelay = 1.2f;

    private string _oldaniname; // 이전 애니메이션 이름

    private void Awake()
    {
        instance = this;
        _animator = GetComponent<Animator>();
        
        _noteInfo = FileManager.ReadFile_TXT(PlayMusicInfo.ReturnSongName() + ".txt", "Notes/");
        _getInfo = _noteInfo[0].Split('/'); // 판정선간격, 감소속도, 롱노트진행속도
        _songDelay = float.Parse(_getInfo[0]) / (float.Parse(_getInfo[1]) * Time.fixedDeltaTime) / (1 / Time.fixedDeltaTime); // 노트 활성화 간격 조정
        
        if (_noteInfo != null)
        {
            for (int i = 1; i < _noteInfo.Count; i++)
            {
                _getInfo = _noteInfo[i].Split('/');
                if (_getInfo.Length == 3)
                    _note.Add(new Note(float.Parse(_getInfo[0]), _getInfo[1], _getInfo[2]));
                else
                    _note.Add(new Note(float.Parse(_getInfo[0]), _getInfo[1], _getInfo[2], _getInfo[3]));
            }

            Invoke("StartMusic", 5.0f); // 음악 재생
        }

        _jointPoints.Add("Lshoulder", _joints[0]);
        _jointPoints.Add("Rshoulder", _joints[1]);
        _jointPoints.Add("Lhand", _joints[2]);
        _jointPoints.Add("Rhand", _joints[3]);
        _jointPoints.Add("Lknee", _joints[4]);
        _jointPoints.Add("Rknee", _joints[5]);
        _jointPoints.Add("Lfoot", _joints[6]);
        _jointPoints.Add("Rfoot", _joints[7]);

        // 애니메이션 클립에 쉽게 접근할 수 있도록 딕셔너리화
        for (int i = 0; i < _animator.runtimeAnimatorController.animationClips.Length; i++)
            _animationIndex.Add(_animator.runtimeAnimatorController.animationClips[i].name, i);
    }

    private void StartMusic()
    {
        _startTime = Time.time;
        _isStart = true;
        SoundManager.instance.Play();
    }

    public void SetAnimation(string animation, bool _isFail = false)
    {
        if (animation == "" && !_isFail)
            return;

        if(_isFail) // 노트 판정 실패
        {
            if (_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "FAIL") // First FAIL
            {
                // 어느 클립에서 실패했는지를 체크해줌
                if (animation == null)
                    _oldaniname = "IDLE";
                else
                    _oldaniname = animation;

                _animator.SetBool(_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name, false); // 현재 클립을 False로 변경
                _animator.SetBool("FAIL", true);
                _aniIndex++;
                _failIndex = 0;
            }
            else // 지속적으로 실패할 경우
            {
                _failIndex++;
                _animator.Play(animation, -1, _failIndex % 2 / _animator.GetCurrentAnimatorClipInfo(0)[0].clip.frameRate);
            }
        }
        else // 성공
        {
            if (_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != animation) // 새로운 애니메이션을 실행해야 하는 경우
            {
                if(_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "FAIL") // 실패 애니메이션에서 넘어가는 경우라면
                {
                    _animator.SetBool("FAIL", false); // FAIL 해제
                    _animator.SetBool(animation, true); // 새 애니메이션으로 변경
                    
                    if (animation == _oldaniname) // 실패 전에 실행된 애니메이션과 넘어가려는 애니메이션이 같은 경우
                        _aniIndex++;
                    else // 다른 경우
                        _aniIndex = 0;
                    _animator.Play(animation, -1, _aniIndex / _animator.runtimeAnimatorController.animationClips[_animationIndex[animation]].frameRate);
                }
                else // 단순히 동작이 바뀌는 경우라면
                {
                    _animator.SetBool(_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name, false);
                    _animator.SetBool(animation, true);
                    _aniIndex = 0;
                }
            }
            else // 현재 애니메이션에서 1프레임씩 올려야 하는 경우
            {
                _aniIndex++;
                _animator.Play(animation, -1, _aniIndex / _animator.GetCurrentAnimatorClipInfo(0)[0].clip.frameRate);
                if (_aniIndex == _animator.GetCurrentAnimatorClipInfo(0)[0].clip.frameRate)
                    _aniIndex = 0;
            }
        }
    }
    public void StopNote()
    {
        _isStart = false;
        SoundManager.instance.Stop();
    }
    public void ResetNote()
    {
        _aniIndex = _index = _upIndex = 0;
        CancelInvoke();
        _isStart = false;
        _animator.SetBool("IDLE", true);
        _oldaniname = "";
        for (int i=1;i<_animator.parameterCount;i++) // 애니메이션 초기화
        {
            if (_animator.parameters[i].type == AnimatorControllerParameterType.Bool) // Bool 타입의 변수(애니메이션 컨트롤)에만 조정
                _animator.SetBool(_animator.parameters[i].name, false);
        }
        Invoke("StartMusic", 5.0f); // 음악 재생
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
                    _upIndex++;
                }
            }

            _index += _upIndex; // 처리된 노트의 인덱스 수만큼 PLUS
            _upIndex = 0; // 처리된 노트 갯수 저장 변수 초기화
            if(_index >= _note.Count)
            {
                _gameClearManager.Invoke("Active", 3.0f);
                _isStart = false;
            }
        }
    }
}
