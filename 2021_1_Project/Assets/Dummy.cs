using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dummy : MonoBehaviour
{
    private Image _aaa;

    private void Awake()
    {
        _aaa = GetComponent<Image>();
    }

    private void Update()
    {
        
    }
}
