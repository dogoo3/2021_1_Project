using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{
    public float activeTime;
    public string joint, notename, animation;

    public Note(float _activeTime, string _joint, string _notename, string _animation = "")
    {
        activeTime = _activeTime;
        joint = _joint;
        notename = _notename;
        animation = _animation;
    }
}
