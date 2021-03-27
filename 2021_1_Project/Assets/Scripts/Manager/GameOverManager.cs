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
        HPManager.instance.ResetHP();
        ComboManager.instance.ResetCombo(false); // 실행 전 반드시 HPManager의 Reset을 해줘야함!
        JudgeManager.instance.ResetJudge();
        SetNote.instance.ResetNote();
        NotePoolingManager.instance.ResetNote();
        gameObject.SetActive(false);
    }

    public void Back() // 선택창으로 돌아가기
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("ChoiceStage");
    }
}
