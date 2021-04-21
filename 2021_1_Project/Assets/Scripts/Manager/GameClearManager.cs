using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClearManager : MonoBehaviour
{
    [Header("0 : AWESOME, 1 : GOOD, 2 : FAIL, 3 : MISS")]
    [SerializeField] private Text[] _score = default;

    public void Active() // 게임완료창 활성화
    {
        if(HPManager.instance.GetHP() > 0)
        {
            Dictionary<string, int> _judge = JudgeManager.instance.GetJudge();
            _score[0].text = _judge["AWESOME"].ToString();
            _score[1].text = _judge["GOOD"].ToString();
            _score[2].text = _judge["FAIL"].ToString();
            _score[3].text = _judge["MISS"].ToString();

            gameObject.SetActive(true);
        }
    }

    public void Restart() // 악곡 재시작
    {
        HPManager.instance.ResetHP();
        ComboManager.instance.ResetCombo(false); // 실행 전 반드시 HPManager의 Reset을 해줘야함!
        JudgeManager.instance.ResetJudge();
        SetNote.instance.ResetNote();
        CutSceneManager.instance.ResetTime();
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
