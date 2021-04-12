using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum JOINT
//{
//    Lshoulder_x,
//    Lshoulder_y,
//    Rshoulder_x,
//    Rshoulder_y,
//    Lhand_x,
//    Lhand_y,
//    Rhand_x,
//    Rhand_y,
//    Lknee_x,
//    Lknee_y,
//    Rknee_x,
//    Rknee_y,
//    Lfoot_x,
//    Lfoot_y,
//    Rfoot_x,
//    Rfoot_y,
//}

public class Motion
{
    public Dictionary<string, Vector2> joint = new Dictionary<string, Vector2>();
    public Sprite _sprite;
    public Motion(string[] _motionInfo, Vector2 _characterPos)
    {
        _sprite = CharacterManager.instance.GetSprite(_motionInfo[0]);
        string[] temp = _motionInfo[1].Split('/');
        joint.Add("Lshoulder", new Vector2(int.Parse(temp[0]) + _characterPos.x, int.Parse(temp[1]) + _characterPos.y));
        temp = _motionInfo[2].Split('/');
        joint.Add("Rshoulder", new Vector2(int.Parse(temp[0]) + _characterPos.x, int.Parse(temp[1]) + _characterPos.y));
        temp = _motionInfo[3].Split('/');
        joint.Add("Lhand", new Vector2(int.Parse(temp[0]) + _characterPos.x, int.Parse(temp[1]) + _characterPos.y));
        temp = _motionInfo[4].Split('/');
        joint.Add("Rhand", new Vector2(int.Parse(temp[0]) + _characterPos.x, int.Parse(temp[1]) + _characterPos.y));
        temp = _motionInfo[5].Split('/');
        joint.Add("Lknee", new Vector2(int.Parse(temp[0]) + _characterPos.x, int.Parse(temp[1]) + _characterPos.y));
        temp = _motionInfo[6].Split('/');
        joint.Add("Rknee", new Vector2(int.Parse(temp[0]) + _characterPos.x, int.Parse(temp[1]) + _characterPos.y));
        temp = _motionInfo[7].Split('/');
        joint.Add("Lfoot", new Vector2(int.Parse(temp[0]) + _characterPos.x, int.Parse(temp[1]) + _characterPos.y));
        temp = _motionInfo[8].Split('/');
        joint.Add("Rfoot", new Vector2(int.Parse(temp[0]) + _characterPos.x, int.Parse(temp[1]) + _characterPos.y));
    }

    public Vector2 ReturnJointPos(string _joint)
    {
        if (joint.ContainsKey(_joint))
            return joint[_joint];
        return Vector2.zero;
    }
}
