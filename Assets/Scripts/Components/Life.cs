using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [Header("Life Setup")]
    public float maxLife = 100f;

    [Header("Debug")]
    [SerializeField] protected float currentLife;

    [Space] public UnityEvent OnDie;
    [Space] public UnityEvent OnRevive;
    
    [HideInInspector] public bool isDead;

    protected virtual void Start()
    {
        SetLife(maxLife);
    }

    public virtual void SetLife(float value)
    {
        if (isDead) return;
        
        // Set new life value
        currentLife = value;
        
        LifeRules();
        UpdateHud();
    }

    public virtual void TakeDamage(float damage)
    {
        if (isDead) return;
        
        // Set new life value
        currentLife += damage;
        
        LifeRules();
        UpdateHud();
    }


    public virtual void Revive()
    {
        currentLife = maxLife;
        isDead = true;

        if (OnRevive != null)
        {
            OnRevive?.Invoke();
        }
    }

    protected virtual void LifeRules()
    {
        if (currentLife > maxLife) 
            currentLife = maxLife;

        // Set Death
        if (currentLife <= 0)
        {
            isDead = true;
            currentLife = 0;
            OnDie?.Invoke();
        }
    }

    protected virtual void UpdateHud()
    {
        if (gameObject.tag == "Player")
        {
            HudManager.Instance.SeLifeHud(currentLife);
        }
    }
}
