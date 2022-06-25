using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : Weapon
{
    [Header("Target Setup")]
    public Life target;
    public LayerMask targetLayer = 8;
    public float findDistance = 5f;
    public float findRate = 1f;

    [Header("Other Settings")]
    public Transform aimPivot;
    public Animator animator;

    protected bool isActive = false;
    protected bool hasTarget = true;

    protected override void Start()
    {
        canFire = false;
    }

    protected override void FixedUpdate()
    {
        if (target != null && !target.isDead)
        {
            var targetPos = target.transform.position;
            aimPivot.LookAt(targetPos);
        }

        if (!canFire) return;
        if (PauseMenu.Instance.IsPaused) return;

        FindTarget();

        if (canFire && isActive && target != null && !target.isDead)
        {
            canFire = false;
            animator.SetTrigger("Fire");
            Rigidbody spawBullet = Instantiate(bullet, pipe.position, pipe.rotation);
            spawBullet.AddForce(pipe.forward * bulletSpeed);
            Invoke(nameof(FireRate), fireRate);
        }
        else animator.SetTrigger("Idle");
    }

    protected virtual void FindTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, findDistance, targetLayer);
        
        for (int i = 0; i < hitColliders.Length; i++)
        {
            var hit = hitColliders[i].transform;

            if (hit != transform && !hit.CompareTag("Player"))
            {
                target = hit.GetComponent<Life>();
            }
        }

        if (hitColliders.Length == 0)
            target = null;
    }

    public void ActiveIn(float time)
    {
        Invoke(nameof(ActiveTurrent), time);
    }

    private void ActiveTurrent()
    {
        canFire = true;
        isActive = true;
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = target != null ? Color.red : Color.green;
        Gizmos.DrawWireSphere(transform.position, findDistance);
    }
}
