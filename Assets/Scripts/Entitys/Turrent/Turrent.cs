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

    protected bool isActive = false;
    protected bool hasTarget = true;

    protected override void Start()
    {
        canFire = false;
    }

    protected override void FixedUpdate()
    {
        if (!canFire) return;
        if (PauseMenu.Instance.IsPaused) return;

        if (canFire && isActive && target != null && !target.isDead)
        {
            canFire = false;
            Rigidbody spawBullet = Instantiate(bullet, pipe.position, pipe.rotation);
            spawBullet.AddForce(pipe.forward * bulletSpeed);
            Invoke("FireRate", fireRate);
        }
    }

    protected void LateUpdate() 
    {
        if (target != null && !target.isDead)
        {
            var targetPos = target.transform.position;
            aimPivot.LookAt(targetPos);
        }
    }

    protected virtual IEnumerator FindTarget()
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

        yield return new WaitForSeconds(findRate);
        

        StartCoroutine(FindTarget());
    }

    public void ActiveIn(float time)
    {
        Invoke(nameof(ActiveTurrent), time);
    }

    private void ActiveTurrent()
    {
        canFire = true;
        isActive = true;
        StartCoroutine(FindTarget());
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = target != null ? Color.red : Color.green;
        Gizmos.DrawWireSphere(transform.position, findDistance);
    }
}
