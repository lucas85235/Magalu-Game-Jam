using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillAimRotate : Skill
{
    public LayerMask inputLayer = ~9;
    public float smoth = 1f;
    protected RaycastHit _hitInfo;
    private Vector2 aim;

    protected override void Awake()
    {
        base.Awake();

        inputActions.Character.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>();
    }

    public override void UseSkill()
    {
        if (Gamepad.current != null)
        {
            Vector3 lookDirection = new Vector3(aim.x, 0, aim.y);
            Quaternion lookRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            float step = smoth * Time.deltaTime;
            model.rotation = Quaternion.Lerp(lookRotation, model.rotation, step);
        }
        else
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out _hitInfo, 100, inputLayer))
            {
                Vector3 playerToMouse = _hitInfo.point - model.position;
                playerToMouse.y = 0;
                Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
                model.rotation = newRotation;
            }
        }
    }
}
