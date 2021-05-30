using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoControl : MonoBehaviour
{
    private Toggle _toggle;
    [SerializeField] private Image _offImage = default;
    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        if (PlayMusicInfo.ReturnAutoMode())
            _toggle.isOn = true;
    }

    public void SetAutoMode()
    {
        PlayMusicInfo.SetAutoMode(_toggle.isOn);
        _offImage.enabled = !_toggle.isOn;
    }
}
