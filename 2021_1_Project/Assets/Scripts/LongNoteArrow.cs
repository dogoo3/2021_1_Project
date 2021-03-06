using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongNoteArrow : MonoBehaviour
{
    [HideInInspector]
    public RectTransform recttransform;
    private Image _image;
    
    private void Awake()
    {
        recttransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }

    private void Update()
    {

    }
}
