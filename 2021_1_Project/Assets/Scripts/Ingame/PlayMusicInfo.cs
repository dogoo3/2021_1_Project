using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayMusicInfo
{
    private static string _song;
    private static bool _isAuto;

    public static void InputMusicInfo(string _song)
    {
        PlayMusicInfo._song = _song;
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
}
