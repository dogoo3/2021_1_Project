using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayMusicInfo
{
    private static string _song;

    public static void InputMusicInfo(string _song)
    {
        PlayMusicInfo._song = _song;
    }

    public static string Return()
    {
        return _song;
    }
}
