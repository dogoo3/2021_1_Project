using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{
    public float activeTime;
    public string joint, notename, sfxName, motion;

    public Note(float _activeTime, string _joint, string _notename, string _sfxName, string _motion = "")
    {
        activeTime = _activeTime;
        joint = _joint;
        notename = _notename;
        sfxName = _sfxName;
        motion = _motion;
    }
}
