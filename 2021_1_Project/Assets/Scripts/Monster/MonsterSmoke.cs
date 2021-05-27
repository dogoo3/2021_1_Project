using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSmoke : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        if (gameObject.activeSelf) // 이미 활성화되어 애니메이션이 실행중인경우
            _animator.Rebind(); // 애니메이터를 리셋해준다.
        else
            gameObject.SetActive(true);
    }
}
