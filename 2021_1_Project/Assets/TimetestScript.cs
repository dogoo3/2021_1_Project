using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimetestScript : MonoBehaviour
{
    private void Awake()
    {
        //Application.targetFrameRate = 10;
        //InvokeRepeating("Set", 0f, 0.5f);
    }
    private void Set()
    {
        Debug.Log("메시지");
    }
    private void Update()
    {
        Debug.Log("update" + Time.time);
    }
}
