using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetNote : MonoBehaviour
{
    public static SetNote instance;

    [SerializeField] private GameClearManager _gameClearManager = default;
    [SerializeField] private RectTransform[] _joints = default;

    private Image _image;
    
    private List<Note> _note = new List<Note>();
    private Dictionary<string, RectTransform> _jointPoints = new Dictionary<string, RectTransform>();
    private Dictionary<string, Motion> _motion = new Dictionary<string, Motion>(); 

    private bool _isStart = false;

    private int _index = 0, _upIndex = 0;
    private int _index_idleFSM = 0, _index_dabFSM = 0, _index_failFSM = 0;

    private float _startTime, _songDelay = 1.2f;

    private string _nowMotion;
    private string[]
        _jointName = { "Lshoulder", "Rshoulder", "Lhand", "Rhand", "Lknee", "Rknee", "Lfoot", "Rfoot", },
        _idleFSM = { "IDLE", "IDLE_1", "IDLE_2", "IDLE_3", "IDLE_4" },
        _dabFSM = { "DAB", "DAB_1", "DAB_2", "DAB_3", "DAB_4", "DAB_5", "DAB_6", "DAB_7", "DAB_8", "DAB_9", "DAB_10", "DAB_11" },
        _failFSM = { "FAIL_1", "FAIL_2" };
    private void Awake()
    {
        instance = this;

        _image = GetComponent<Image>();

        #region ReadNoteFIle
        List<string> _tempStringList = FileManager.ReadFile_TXT(PlayMusicInfo.ReturnSongName() + ".txt", "Notes/");
        string[] _getInfo = _tempStringList[0].Split('/'); // 판정선간격, 감소속도, 롱노트진행속도
        _songDelay = float.Parse(_getInfo[0]) / (float.Parse(_getInfo[1]) * Time.fixedDeltaTime) / (1 / Time.fixedDeltaTime); // 노트 활성화 간격 조정
        
        if (_tempStringList != null)
        {
            for (int i = 1; i < _tempStringList.Count; i++)
            {
                _getInfo = _tempStringList[i].Split('/');
                if (_getInfo.Length == 4)
                    _note.Add(new Note(float.Parse(_getInfo[0]), _getInfo[1], _getInfo[2], _getInfo[3])); // 시간, 관절, 노트, 효과음
                else
                    _note.Add(new Note(float.Parse(_getInfo[0]), _getInfo[1], _getInfo[2], _getInfo[3], _getInfo[4])); // 시간, 관절, 노트, 효과음, 모션
            }

            Invoke("StartMusic", 5.0f); // 음악 재생
        }
        #endregion
        #region ReadMotionFile
        _tempStringList = FileManager.ReadFile_TXT("Motion_posInfo.csv", "", true);

        for (int i = 0; i < _tempStringList.Count; i++)
        {
            string[] _t = _tempStringList[i].Split(',');
            _motion.Add(_t[0], new Motion(_t, transform.position));
        }
        #endregion
        #region InputJointObject
        for (int i = 0; i < _joints.Length; i++)
            _jointPoints.Add(_jointName[i], _joints[i]);
        #endregion

        InvokeRepeating("FSM_IDLE", 0, 0.1f);
    }

    private void StartMusic()
    {
        _startTime = Time.time;
        _isStart = true;
        SoundManager.instance.Play();
    }

    private void FSM_DAB()
    {
        _image.sprite = _motion[_dabFSM[_index_dabFSM]]._sprite;
        _index_dabFSM++;
        if (_index_dabFSM >= _dabFSM.Length)
            CancelInvoke("FSM_DAB");
    }

    private void FSM_IDLE()
    {
        _image.sprite = _motion[_idleFSM[_index_idleFSM % _idleFSM.Length]]._sprite;
        _index_idleFSM++;
        foreach (KeyValuePair<string, RectTransform> items in _jointPoints)
            _jointPoints[items.Key].position = _motion[_idleFSM[_index_idleFSM % _idleFSM.Length]].joint[items.Key];
    }

    public int SetMotion(string _motion, bool _isFail = false)
    {
        if (_isFail) // 실패 애니메이션일 경우
        {
            if(_motion == "MOTION3_L_2" || _motion == "MOTION3_R_2")
            {
                
            }
            else
            {
                if (IsInvoking("FSM_IDLE"))
                    CancelInvoke("FSM_IDLE");

                _image.sprite = this._motion[_failFSM[_index_failFSM % _failFSM.Length]]._sprite;

                foreach (KeyValuePair<string, RectTransform> items in _jointPoints)
                    _jointPoints[items.Key].position = this._motion[_failFSM[_index_failFSM % _failFSM.Length]].joint[items.Key];
                _index_failFSM++;
                return _index_failFSM - 1;
            }
        }
        else if(_motion == "MOTION3_L_2" || _motion == "MOTION3_R_2")
        {
            if (_image.sprite.name.Substring(0, 7) == "MOTION3") // 이전 노트 판정에 성공했을 경우
                _image.sprite = this._motion[_motion]._sprite;
            else // 이전 노트 판정에 실패했을 경우
                InvokeRepeating("FSM_IDLE", 0, 0.1f);
        }
        else if (_motion != "") // 다른 모션일 경우
        {
            _image.sprite = this._motion[_motion]._sprite;
            if (_motion == "DAB") // 노래가 끝나는 모션
            {
                if (IsInvoking("FSM_IDLE"))
                    CancelInvoke("FSM_IDLE");
                InvokeRepeating("FSM_DAB", 0, 0.1f);
            }
            else if (_motion == "IDLE") 
                InvokeRepeating("FSM_IDLE", 0, 0.1f);
            else
            {
                if (IsInvoking("FSM_IDLE")) // 아이들에서 다른 모션으로 넘어갈 때
                    CancelInvoke("FSM_IDLE");
            }
            foreach (KeyValuePair<string, RectTransform> items in _jointPoints)
                _jointPoints[items.Key].position = this._motion[_motion].joint[items.Key];
            _index_failFSM = 0;
        }
        else
            return 0;
        return 0;
    }
    public void StopNote()
    {
        _isStart = false;
        SoundManager.instance.Stop();
    }
    public void ResetNote()
    {
        _index = _upIndex = _index_idleFSM = _index_dabFSM = 0;
        CancelInvoke();
        _isStart = false;
        _index_failFSM = 0;
        InvokeRepeating("FSM_IDLE", 0, 0.1f);
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
                    if (_note[i].motion == "")
                        NotePoolingManager.instance.GetNote(_jointPoints[_note[i].joint].position, _note[i].notename, _note[i].sfxName);
                    else
                        NotePoolingManager.instance.GetNote(_motion[_note[i].motion].joint[_note[i].joint], _note[i].notename, _note[i].sfxName, _note[i].motion);

                    _upIndex++;
                }
            }

            _index += _upIndex; // 처리된 노트의 인덱스 수만큼 PLUS
            _upIndex = 0; // 처리된 노트 갯수 저장 변수 초기화
            if(_index >= _note.Count)
            {
                _gameClearManager.Invoke("Active", 5.0f);
                _isStart = false;
            }
        }
    }
}
