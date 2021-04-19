using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion
{
    public Dictionary<string, Vector2> joint = new Dictionary<string, Vector2>();
    public Sprite _sprite;
    public Motion(string[] _motionInfo, Vector2 _characterPos)
    {
        string[] temp;
        _sprite = CharacterManager.instance.GetSprite(_motionInfo[0]);
        for(int i=1;i<12;i++) // 인덱스는 1부터 시작, 
        {
            temp = _motionInfo[i].Split('/');
            joint.Add(PlayMusicInfo.ReturnJointName(i - 1), new Vector2(int.Parse(temp[0]) + _characterPos.x, int.Parse(temp[1]) + _characterPos.y));
        }
    }

    public Vector2 ReturnJointPos(string _joint)
    {
        if (joint.ContainsKey(_joint))
            return joint[_joint];
        return Vector2.zero;
    }
}
