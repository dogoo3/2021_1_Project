using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource _song = default;
    [SerializeField] private AudioSource[] _sfxs = default;

    private Dictionary<string, AudioClip> _sfxList = new Dictionary<string, AudioClip>(16);
    
    private void Awake()
    {
        instance = this;
        AudioClip[] _audio = Resources.LoadAll<AudioClip>("Sounds/SFX/");
        for (int i = 0; i < _audio.Length; i++)
            _sfxList.Add(_audio[i].name, _audio[i]);
        DontDestroyOnLoad(this);
    }

    public void PlayPreListen(AudioClip _song, float _startpos)
    {
        this._song.clip = _song;
        this._song.time = _startpos;
        this._song.Play();
    }

    public void ResetStartTime()
    {
        _song.time = 0f;
    }

    public void Play()
    {
        _song.Play();
    }

    public void PlaySFX(string _sfxName)
    {
        if (_sfxList.ContainsKey(_sfxName))
        {
            for (int i = 0; i < _sfxs.Length; i++)
            {
                if (!_sfxs[i].isPlaying)
                {
                    _sfxs[i].clip = _sfxList[_sfxName];
                    _sfxs[i].Play();
                    break;
                }
            }
        }
    }

    public void Stop()
    {
        _song.Stop();
    }

    public void SetVolumeValue(float _value)
    {
        _song.volume = _value;
        for (int i = 0; i < _sfxs.Length; i++)
            _sfxs[i].volume = _value;
    }

    public void SetSoundPower(bool _is)
    {
        _song.mute = _is;
        for (int i = 0; i < _sfxs.Length; i++)
            _sfxs[i].mute = _is;
    }
}
