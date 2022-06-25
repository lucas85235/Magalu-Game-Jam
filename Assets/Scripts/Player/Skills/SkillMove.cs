using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMove : Skill
{
    protected Animator _animator;

    [Header("Move")]
    public float speed = 2.5f;
    public float runSpeed = 3.5f;

    public virtual void Start() 
    {
        _animator = model.GetComponent<Animator>();
    }

    public override void UseSkill()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var tempSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;
        transform.position +=  move * Time.deltaTime * tempSpeed;

        if (move.x != 0 || move.z != 0)
        {
            if (_animator != null) _animator.SetBool("Move", true);
            if (_animator != null) _animator.SetFloat("Speed", Input.GetKey(KeyCode.LeftShift) ? move.normalized.magnitude * 1.2f : move.normalized.magnitude);
        }
        else if (_animator != null) _animator.SetBool("Move", false);
    }
}
