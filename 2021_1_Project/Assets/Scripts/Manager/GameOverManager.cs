using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void Active() // 게임완료창 활성화
    {
        gameObject.SetActive(true);
    }

    public void Restart() // 악곡 재시작
    {
        ComboManager.instance.ResetCombo();
        JudgeManager.instance.ResetJudge();
        if(CutSceneManager.instance != null)
            CutSceneManager.instance.ResetTime();
        if (MonsterManager.instance != null)
            MonsterManager.instance.Init();
        SetNote.instance.ResetNote();
        SoundManager.instance.Stop();
        gameObject.SetActive(false);
    }

    public void Back() // 선택창으로 돌아가기
    {
        gameObject.SetActive(false);
        SoundManager.instance.Stop();
        SceneManager.LoadScene("ChoiceStage");
    }
}
