using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    [SerializeField] private Sprite[] _atlas = default;
    private Dictionary<string, Sprite> _character = new Dictionary<string, Sprite>();

    private void Awake()
    {
        instance = this;

        for (int i = 0; i < _atlas.Length; i++)
            _character.Add(_atlas[i].name, _atlas[i]);

        DontDestroyOnLoad(this);
    }

    public Sprite GetSprite(string _motionName)
    {
        if (_character.ContainsKey(_motionName))
            return _character[_motionName];
        return null;
    }
}
