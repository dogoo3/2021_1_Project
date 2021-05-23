using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance;

    [SerializeField] private SelectMonster[] _monsters = default;
    [SerializeField] private Image _gauge = default;
    [SerializeField] private Color _failColor = default;
    [SerializeField] private Color _successColor = default;

    private void Awake()
    {
        instance = this;
    }

    public void ChoiceMonster(string _type)
    {
        if(_type == "_A") // Choice Red, Enemy = 
        {
            _monsters[1].NonSelect();
        }
        else // Choice Blue
        {
            _monsters[0].NonSelect();
        }
    }
}
