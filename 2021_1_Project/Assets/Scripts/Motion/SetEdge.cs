using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetEdge : MonoBehaviour
{
    public static SetEdge instance;

    [SerializeField] private Sprite[] _edgeSprite = default;

    private Image _image;
    private Color _color;

    private Dictionary<string, Sprite> _edge = new Dictionary<string, Sprite>();

    private void Awake()
    {
        instance = this;

        _image = GetComponent<Image>();
        for (int i = 0; i < _edgeSprite.Length; i++) // Edge Image 등록
            _edge.Add(_edgeSprite[i].name, _edgeSprite[i]);
    }

    private void Transparent()
    {
        _color.a -= 0.1f;
        _image.color = _color;
        if (_color.a <= 0f)
            CancelInvoke("Transparent");
    }
    public void SetEdgeImage(string _edgeName)
    {
        if(_edge.ContainsKey(_edgeName))
        {
            if (_edgeName == "MOTION3_L_2_EDGE" && _image.sprite.name != "MOTION3_L_1_EDGE" ||
                _edgeName == "MOTION3_R_2_EDGE" && _image.sprite.name != "MOTION3_R_1_EDGE") // 일부 모션에서는 EdgeImage를 표현하지 않습니다.
                return;
            _image.sprite = _edge[_edgeName];
            _color = Color.white;
            InvokeRepeating("Transparent", 0f, 0.05f);
        }
    }
}
