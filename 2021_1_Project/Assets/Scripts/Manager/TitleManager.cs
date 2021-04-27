using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public static TitleManager instance;

    [SerializeField] private GameObject _optionWindow = default;

    private Stack<GameObject> _activeWindow = new Stack<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    public void ClickChoiceStage()
    {
        SceneManager.LoadScene("ChoiceStage");
        instance = null;
    }

    public void ExitGame()
    {
        Application.Quit();
        instance = null;
    }

    public void ActiveOptionWindow()
    {
        _optionWindow.SetActive(true);
        _activeWindow.Push(_optionWindow);
    }

    public void HideWindow()
    {
        if (_activeWindow.Count != 0)
            _activeWindow.Pop().SetActive(false);
        else
            ExitGame();
    }

    private void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                HideWindow();
        }
    }
}
