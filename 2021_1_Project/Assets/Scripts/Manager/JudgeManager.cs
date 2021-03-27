using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeManager : MonoBehaviour
{
    public static JudgeManager instance;

    [Header("0 : Awesome, 1 : Good, 2 : Fail, 3 : Miss")]
    [SerializeField] private Sprite[] _judgeSprite = default;
    [Header("사이즈 증가값")]
    [SerializeField] private float _creaseSize = default;

    private Image _image_judge;

    private Vector3 _size = Vector3.one;
    
    private Dictionary<string, Sprite> _judgeImage = new Dictionary<string, Sprite>();
    private Dictionary<string, int> _judgeCount = new Dictionary<string, int>();
    private Color _color = Color.white;

    private bool _isSetJudge, _isTransparent;

    private float _showJudgetime;

    private void Awake()
    {
        instance = this;
        _image_judge = GetComponent<Image>();

        // Dictionary에 이미지 등록
        _judgeImage.Add("AWESOME", _judgeSprite[0]);
        _judgeImage.Add("GOOD", _judgeSprite[1]);
        _judgeImage.Add("FAIL", _judgeSprite[2]);
        _judgeImage.Add("MISS", _judgeSprite[3]);

        _judgeCount.Add("AWESOME", 0);
        _judgeCount.Add("GOOD", 0);
        _judgeCount.Add("FAIL", 0);
        _judgeCount.Add("MISS", 0);

        _size = Vector2.one * 0.8f;
        _size.z = 1.0f;
        _showJudgetime = 1.0f;
    }

    public void SetJudgeImage(string _judge)
    {
        _size = Vector2.one * 0.8f; // 사이즈 조정
        _size.z = 1.0f;
        _showJudgetime = 0f; // 일정시간 이상 지나면 투명해지는 변수 초기화
        _color.a = 1.0f;
        _image_judge.color = _color;
        _isTransparent = false;
        _judgeCount[_judge]++; // 판정 변수 카운팅
        _image_judge.rectTransform.localScale = _size;
        _image_judge.sprite = _judgeImage[_judge];
        _isSetJudge = true;
    }

    public void ResetJudge()
    {
        _judgeCount["AWESOME"] = 0;
        _judgeCount["GOOD"] = 0;
        _judgeCount["FAIL"] = 0;
        _judgeCount["MISS"] = 0;
    }

    public Dictionary<string, int> GetJudge()
    {
        return _judgeCount;
    }

    private void FixedUpdate()
    {
        if(_isSetJudge)
        {
            _size.x += _creaseSize;
            _size.y += _creaseSize;
            _image_judge.rectTransform.localScale = _size;
            if(_image_judge.rectTransform.localScale.x >= 1.0f)
            {
                _image_judge.rectTransform.localScale = Vector3.one;
                _isSetJudge = false;
            }
        }
        if(_showJudgetime <= 0.5f)
        {
            _showJudgetime += Time.deltaTime;
            _isTransparent = true;
        }
        if(_isTransparent)
        {
            _color.a -= 0.03136f;
            _image_judge.color = _color;
            if (_color.a <= 0f)
                _isTransparent = false;
        }
    }
}
