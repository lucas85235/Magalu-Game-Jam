using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Life))]

public class Player : MonoBehaviour
{
    protected Life _life;
    protected Rigidbody _rb;
    protected Skill[] skills;

    [Header("Player Setup")]
    public Transform model;

    [Header("Player Inventory")]
    public GameObject inventory;

    public Life life { get => _life; private set => _life = value; }

    protected PlayerCharControls inputActions;

    protected virtual void Awake()
    {
        skills = GetComponents<Skill>();

        _life = GetComponent<Life>();
        _rb = GetComponent<Rigidbody>();

        _life.OnDie.AddListener(CharacterDead);

        inventory.SetActive(false);

        inputActions = new PlayerCharControls();

        inputActions.Interface.Inventory.performed += _ =>
        {
            if (!_life.isDead)
            {
                PauseMenu.Instance.SetPause(!inventory.activeSelf);
                inventory.SetActive(!inventory.activeSelf);
            }
        };
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    protected virtual void Update()
    {
        if (PauseMenu.Instance.IsPaused) return;

        if (!_life.isDead)
        {
            // Use Skills
            foreach (var skill in skills)
            {
                skill.UseSkill();
            }
        }
    }
    
    protected virtual void CharacterDead()
    {
        _rb.useGravity = false;
        _rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
