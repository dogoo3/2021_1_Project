using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEgg : MonoBehaviour
{
    private Slider _pitchValue;

    private void Awake()
    {
        _pitchValue = GetComponent<Slider>();
    }

    private void Start()
    {
        _pitchValue.value = PlayMusicInfo.ReturnPitch();
    }
    public void ChangeValue()
    {
        Time.timeScale = _pitchValue.value;
        PlayMusicInfo.SetPitch(_pitchValue.value);
        SoundManager.instance.SetPitchValue(_pitchValue.value);
    }
}
