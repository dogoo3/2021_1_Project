using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectMonster : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _monsterType = default;
    [SerializeField] private MonsterSmoke _smoke = default;

    private Animator _animator;

    private Image _image;

    private float _lerpValue;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _smoke.Enable();
    }

    private void OnDisable()
    {
        _smoke.Enable();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayMusicInfo.AppendMusicInfo(_monsterType); // 노래의 세부타입을 설정함
        NotePoolingManager.instance.ReadNoteFile(); // 노트 풀링을 가져옴
        CutSceneManager.instance.GetCutScene(); // 최종 선택된 노래의 컷씬파일을 가져옴
        MonsterManager.instance.ChoiceMonster(_monsterType); // 상호작용을 시작할 몬스터를 설정해줌
        AttackMotionManager.instance.GetMotion(); // 최종 선택된 노래의 모션파일을 가져옴
        MonsterManager.instance.StartMusic(); // 게이지 활성화 및 장막 투명화
        SetNote.instance.ReadNoteFile(); // 최종 선택된 노래의 채보파일을 읽어오면서 게임 시작
        _animator.enabled = false;
        _image.raycastTarget = false;
    }

    public void NonSelect()
    {
        _image.raycastTarget = false;
        _animator.enabled = false;
    }

    public string GetMotionName()
    {
        return _image.sprite.name;
    }

    public void SetMotion(Sprite _motion)
    {
        _image.sprite = _motion;
    }
}
