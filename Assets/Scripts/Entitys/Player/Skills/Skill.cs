using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected Transform model;
    protected PlayerCharControls inputActions;

    protected virtual void Awake()
    {
        inputActions = new PlayerCharControls();
        model = GetComponent<Player>().model;
    }

    protected virtual void OnEnable()
    {
        inputActions.Enable();
    }

    protected virtual void OnDisable()
    {
        inputActions.Disable();
    }

    public abstract void UseSkill();
}
