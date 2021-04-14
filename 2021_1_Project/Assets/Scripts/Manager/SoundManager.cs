using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource _song;
    [SerializeField] private AudioSource[] _sfxs;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
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

    public void PlaySFX()
    {
        for (int i = 0; i < _sfxs.Length; i++)
        {
            if (!_sfxs[i].isPlaying)
            {
                _sfxs[i].Play();
                break;
            }
        }
    }

    public void Stop()
    {
        _song.Stop();
    }
}
