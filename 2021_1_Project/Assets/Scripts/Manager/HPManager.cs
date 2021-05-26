using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 * NOT USE SCRIPT
 */

public class HPManager : MonoBehaviour
{
    public static HPManager instance;

    [SerializeField] private Sprite _normalHeart = default;
    [SerializeField] private Sprite[] _brokenHeart = default;
    [SerializeField] private Image[] _image_heart = default;

    private int _nowliveHeart;

    private void Awake()
    {
        instance = this;
        ResetHP(); // 하트의 최대갯수 설정
    }

    public void CreaseHP()
    {
        if (_nowliveHeart < _image_heart.Length) // overflow 방지
        {
            _nowliveHeart++;
            _image_heart[_nowliveHeart - 1].sprite = _normalHeart;
        }
    }

    public int DecreaseHP()
    {
        if (_nowliveHeart > 0)
        {
            _image_heart[_nowliveHeart - 1].sprite = _brokenHeart[Random.Range(0, 2)]; // 체력 이미지 변경
            _nowliveHeart--; // 현재 HP 감소
            return _nowliveHeart; // 0 리턴하면 바로 게임 종료하게 함
        }
        return -1; // IndexOutOfRange Error
    }

    public void ResetHP()
    {
        _nowliveHeart = _image_heart.Length; // 하트의 최대갯수 설정
        for (int i = 0; i < _image_heart.Length; i++) // 이미지 변경
            _image_heart[i].sprite = _normalHeart;
    }

    public int GetHP()
    {
        return _nowliveHeart;
    }
}
