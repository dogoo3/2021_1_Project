using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectMonster : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _monsterType = default;

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayMusicInfo.AppendMusicInfo(_monsterType);
        // 몬스터 매니저를 만들어서 선택되지 않은 몬스터 처리
        SetNote.instance.ReadNoteFile();
        NotePoolingManager.instance.ReadNoteFile();
    }
}
