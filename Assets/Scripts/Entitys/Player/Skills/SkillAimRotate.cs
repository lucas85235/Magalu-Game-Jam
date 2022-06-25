using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAimRotate : Skill
{
    public LayerMask inputLayer = ~9;

    protected RaycastHit _hitInfo;

    public override void UseSkill()
    {
        if (PauseMenu.Instance.IsPaused) return;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hitInfo, 100, inputLayer))
        {
            Vector3 playerToMouse = _hitInfo.point - model.position;
            playerToMouse.y = 0;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            model.rotation = newRotation;
        }
    }
}
