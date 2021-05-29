using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameClearManager : MonoBehaviour
{
    [Header("0 : AWESOME, 1 : GOOD, 2 : FAIL, 3 : MISS")]
    [SerializeField] private TextMeshProUGUI[] _score = default;

    public void Active() // 게임완료창 활성화
    {
        Dictionary<string, int> _judge = JudgeManager.instance.GetJudge();
        _score[0].text = _judge["AWESOME"].ToString();
        _score[1].text = _judge["GOOD"].ToString();
        _score[2].text = _judge["FAIL"].ToString();
        _score[3].text = _judge["MISS"].ToString();

        gameObject.SetActive(true);
    }

    public void Restart() // 악곡 재시작
    {
        ComboManager.instance.ResetCombo();
        JudgeManager.instance.ResetJudge();
        if (CutSceneManager.instance != null)
            CutSceneManager.instance.ResetTime();
        if (MonsterManager.instance != null)
        {
            MonsterManager.instance.Init();
            MonsterManager.instance.SetTime();
        }
        SetNote.instance.ResetNote();
        AttackMotionManager.instance.SetTime();
        SoundManager.instance.Stop();
        BackgroundManager.instance.Init();
        gameObject.SetActive(false);
    }

    public void Back() // 선택창으로 돌아가기
    {
        gameObject.SetActive(false);
        SoundManager.instance.Stop();
        SceneManager.LoadScene("ChoiceStage");
    }
}
