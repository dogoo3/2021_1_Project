using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoControl : MonoBehaviour
{
    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    public void SetAutoMode()
    {
        Debug.Log(_toggle.isOn);
        PlayMusicInfo.SetAutoMode(_toggle.isOn);
    }
}
