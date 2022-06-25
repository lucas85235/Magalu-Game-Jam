using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMove : Skill
{
    protected Animator _animator;
    protected PlayerCharControls inputActions;

    [Header("Move")]
    public float speed = 2.5f;
    public float runSpeed = 3.5f;

    private Vector2 movement;
    private float currentSpeed;

    private void Awake()
    {
        currentSpeed = speed;

        inputActions = new PlayerCharControls();

        inputActions.Character.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        inputActions.Character.Movement.canceled += _ => movement = Vector2.zero;

        inputActions.Character.Sprint.performed += _ => currentSpeed = runSpeed;
        inputActions.Character.Sprint.performed += _ => currentSpeed = speed;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public virtual void Start() 
    {
        _animator = model.GetComponent<Animator>();
    }

    public override void UseSkill()
    {
        transform.position += new Vector3(movement.x, 0, movement.y) * Time.deltaTime * currentSpeed;

        if (movement.x != 0 || movement.y != 0)
        {
            if (_animator != null)
            {
                _animator.SetBool("Move", true);
            }
            if (_animator != null)
            {
                _animator.SetFloat("Speed", currentSpeed == runSpeed ? movement.normalized.magnitude * 1.2f : movement.normalized.magnitude);
            }
        }
        else if (_animator != null)
        {
            _animator.SetBool("Move", false);
        }
    }
}
