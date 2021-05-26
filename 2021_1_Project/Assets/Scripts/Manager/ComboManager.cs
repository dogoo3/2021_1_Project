using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public static ComboManager instance;

    private TextMeshProUGUI _comboText;

    private bool _isUpCombo;
    
    private int _combo;

    private float _textsize;
    [SerializeField] private GameOverManager _gameOverManager = default;
    [Header("폰트 사이즈 감소량")]
    [SerializeField] private float _decreaseFontsizeValue = default;
    [Header("콤보증가시 커질 폰트 사이즈 배율")]
    [SerializeField] private float _creaseMagnification = 1.18f;
    
    //[Header("N콤보마다 HP 1씩 증가")]
    //[SerializeField] private int _creaseHpCombo = 2;
    private void Awake()
    {
        instance = this;
        _comboText = GetComponent<TextMeshProUGUI>();
        _textsize = _comboText.fontSize; // 텍스트 폰트 사이즈 저장(효과를 위해)
    }

    private void FixedUpdate()
    {
        if (_isUpCombo)
        {
            _comboText.fontSize = Mathf.Clamp(_comboText.fontSize - _decreaseFontsizeValue, _textsize, _textsize * _creaseMagnification);
            if (_comboText.fontSize == _textsize) // 원래 사이즈로 돌아오게되면
                _isUpCombo = false;
        }
    }

    public void CreaseCombo()
    {
        _comboText.fontSize = _textsize * _creaseMagnification; // 사이즈 조정
        _combo++; // 콤보 1 증가
        _comboText.text = _combo.ToString(); // 콤보 숫자 표시
        _isUpCombo = true; // 효과를 위한 Update 진행
    }

    public void ResetCombo()
    {
        _combo = 0;
        _comboText.text = "";
    }

    public void GameOver()
    {
        SetNote.instance.StopNote();
        NotePoolingManager.instance.ResetNote();
        CutSceneManager.instance.ResetTime();
        _gameOverManager.Active();
    }
}
