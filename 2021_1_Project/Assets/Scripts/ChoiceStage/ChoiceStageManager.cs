using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceStageManager : MonoBehaviour
{
    public static ChoiceStageManager instance;

    private List<string> _songInfo = new List<string>();

    [Header("항목 기본값 오브젝트, 오브젝트의 세로 길이")]
    [SerializeField] private Song _songDefault = default;
    [SerializeField] private float _heightSize = default;

    [Header("스크롤 뷰 컨텐츠 부모 오브젝트")]
    [SerializeField] private RectTransform _content = default;
    private string[] _tempString;

    private string _choiceSongname = "";

    private void Awake()
    {
        instance = this;

        _songInfo = FileManager.ReadFile_TXT("SongInfo.txt","",true); // 곡 정보를 불러온다
        
        _content.sizeDelta = new Vector2(_content.sizeDelta.x, _heightSize * _songInfo.Count); // content의 height를 맞춰 scroll이 가능하도록 조정

        for (int i = 0; i < _songInfo.Count; i++)
        {
            _songDefault.SetValue(_songInfo[i].Split(','));
            Instantiate(_songDefault, Vector2.zero, Quaternion.identity, _content);
        }
    }
    public void ChoiceSong(AudioClip _song, float _highlightpos)
    {
        if(_choiceSongname == _song.name) // 이전에 선택한 악곡과 같은 이름 -> 2번 동시 터치
        {
            SoundManager.instance.ResetStartTime();
            SoundManager.instance.Stop();
            PlayMusicInfo.InputMusicInfo(_song.name);
            SceneManager.LoadScene("Ingame");
        }
        else
        {
            _choiceSongname = _song.name; // 선택한 악곡의 파일명으로 변경
            SoundManager.instance.PlayPreListen(_song, _highlightpos); // 새로운 미리듣기 음악으로 변경
        }
    }
}
