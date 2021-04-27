using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] private Slider _volumeControl = default;
    [SerializeField] private Toggle _soundControl = default;
    [SerializeField] private Image _soundOffToggleImage = default;

    public void ToggleControl()
    {
        SoundManager.instance.SetSoundPower(!_soundControl.isOn);
        _soundOffToggleImage.enabled = !_soundControl.isOn;
    }

    public void VolumeControl()
    {
        SoundManager.instance.SetVolumeValue(_volumeControl.value);
    }

    public void DisableOptionWindow()
    {
        TitleManager.instance.HideWindow();
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                TitleManager.instance.HideWindow();
        }
    }
}
