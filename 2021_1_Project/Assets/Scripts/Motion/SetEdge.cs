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
            _image.sprite = _edge[_edgeName];
            _color = Color.white;
            InvokeRepeating("Transparent", 0f, 0.05f);
        }
    }
}
