using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager instance;

    [Header("Object")]
    [SerializeField] private Image _oriUp = default;
    [SerializeField] private Image _newUp = default;
    [SerializeField] private Image _oriDown = default;
    [SerializeField] private Image _newDown = default;

    [Header("Sprite")]
    [SerializeField] private Sprite _oriUpSprite = default;
    [SerializeField] private Sprite _newUpSprite = default;
    [SerializeField] private Sprite _oriDownSprite = default;
    [SerializeField] private Sprite _newDownSprite = default;

    private Color _oriColor = new Color(1, 1, 1, 0), _newColor = Color.white;

    private void Awake()
    {
        instance = this;
    }
    public void Change()
    {
        // 보여질 오브젝트의 스프라이트 변경
        _oriUp.sprite = _newUpSprite; 
        _oriDown.sprite = _newDownSprite;
        // 컬러 알파값 변경
        _oriUp.color = _oriDown.color = _oriColor;
        _newUp.color = _newDown.color = _newColor;
        InvokeRepeating("ChangeImage", 0f, 0.1f);
    }

    private void ChangeImage()
    {
        _oriColor.a += 0.05f;
        _newColor.a -= 0.05f;
        _oriUp.color = _oriDown.color = _oriColor;
        _newUp.color = _newDown.color = _newColor;
        if (_oriColor.a >= 1.0f)
            CancelInvoke("ChangeImage");
    }

    public void Init()
    {
        // 원래 이미지로 초기화
        _oriUp.sprite = _newUp.sprite = _oriUpSprite;
        _oriDown.sprite = _newDown.sprite = _oriDownSprite;
        // 원래 색상으로 초기화
        _oriColor = new Color(1, 1, 1, 0);
        _newColor = Color.white;
        // 바꿔치기할 이미지 오브젝트 비활성화
        _newUp.gameObject.SetActive(false);
        _newDown.gameObject.SetActive(false);
    }
}
