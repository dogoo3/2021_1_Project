using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneViewer : MonoBehaviour
{
    public void PlaySFX(string _sfxName)
    {
        SoundManager.instance.PlaySFX(_sfxName);
    }
}
