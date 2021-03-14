using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audiosource;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }

    public void PlayPreListen(AudioClip _song, float _startpos)
    {
        audiosource.clip = _song;
        audiosource.time = _startpos;
        audiosource.Play();
    }

    public void ResetStartTime()
    {
        audiosource.time = 0f;
    }

    public void Play()
    {
        audiosource.Play();
    }

    public void Stop()
    {
        audiosource.Stop();
    }
}
