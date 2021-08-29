using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneViewer : MonoBehaviour
{
    public void PlaySFX(string _sfxName) // 원하는 컷씬 위치에서 효과음을 재생해준다.
    {
        SoundManager.instance.PlaySFX(_sfxName);
    }

    public void Destroy() // 컷씬 마지막에 컷씬을 파괴한다.(그 씬에선 다신 보여주지는 않는다)
    {
        transform.parent.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void ChangeMonsterType(string _type) // 게이지를 올릴 몬스터의 타입을 변경해준다
    {
        // MonsterManager.instance.ChangeMonsterType(_type);
    }
}
