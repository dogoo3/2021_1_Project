using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNote : MonoBehaviour
{
    public GameObject _obj;

    private void Awake()
    {
        InvokeRepeating("Set", 1.0f, 6.0f);
    }

    private void Set()
    {
        _obj.gameObject.SetActive(true);
    }
}
