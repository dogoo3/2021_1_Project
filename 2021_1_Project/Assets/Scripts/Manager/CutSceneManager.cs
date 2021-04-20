using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager instance;

    private void Awake()
    {
        instance = this;
        // 노래에 맞는 컷씬 연출 프리팹 가져오기
        GameObject _temp = Instantiate(Resources.Load<GameObject>("Cutscene/" + PlayMusicInfo.ReturnSongName()));
        _temp.transform.SetParent(transform, false);
        _temp.SetActive(false);
    }
}
