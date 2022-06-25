using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected Transform model;

    protected virtual void Awake()
    {
        model = GetComponent<Player>().model;
    }

    public abstract void UseSkill();
}
