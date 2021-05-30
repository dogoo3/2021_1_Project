﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayMusicInfo
{
    private static string _song;
    private static bool _isAuto;
    private static float _pitch;

    private static string[] _joint = { "Lshoulder", "Rshoulder", "Lelbow", "Relbow", "stomach", "Lhand", "Rhand", "Lknee", "Rknee", "Lfoot", "Rfoot" };
    public static void InputMusicInfo(string _song)
    {
        PlayMusicInfo._song = _song;
    }
    public static void AppendMusicInfo(string _appendSong)
    {
        _song += _appendSong;
    }

    public static string ReturnSongName()
    {
        return _song;
    }

    public static void SetAutoMode(bool _is)
    {
        _isAuto = _is;
    }

    public static bool ReturnAutoMode()
    {
        return _isAuto;
    }
    
    public static string ReturnJointName(int _index)
    {
        return _joint[_index];
    }

    public static float ReturnPitch()
    {
        return _pitch;
    }

    public static void SetPitch(float _value)
    {
        _pitch = _value;
    }
}
