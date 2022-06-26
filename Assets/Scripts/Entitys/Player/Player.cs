﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Life))]

public class Player : MonoBehaviour
{
    private int currentXP = 0;
    private int xpToNextLevel = 5;
    private int currentLevel = 1;

    protected Life _life;
    protected Rigidbody _rb;
    protected Skill[] skills;

    protected SkillMove skillMove;
    
    [HideInInspector]
    public int bonusDamage = 0;

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

        TryGetComponent(out skillMove);

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

    public void ReceiveExperience(int value)
    {
        currentXP += value;

        if(currentXP >= xpToNextLevel * currentLevel)
        {
            GameManager.Instance.ActivateUpgradePanel();
        }
    }

    public void UpgradeVelocity()
    {
        skillMove.speed *= 1.1f;
        skillMove.runSpeed *= 1.1f;
    }

    public void UpgradeLife()
    {
        _life.UpgradeLife();
    }

    public void UpgradeDamage()
    {
        bonusDamage++;
    }

    public void UpgradeDefence()
    {
        _life.defence++;
    }
}
