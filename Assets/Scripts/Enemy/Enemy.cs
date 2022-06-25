using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    protected Life _life;
    protected NavMeshAgent _nav;
    protected Animator _animator;
    protected bool canAttack = true;

    [Header("Enemy")]
    public Transform model;

    [Header("Target Setup")]
    public Transform target;
    public float distanceToAttack = 2f;
    public float updateTargetPosition = 1f;
    public float detectDistance = 10f;

    [Header("Enemy Status")]
    public float damage = 10f;
    public float attackRate = 1f;

    public float TargetDistance => Vector3.Distance(transform.position, target.position);

    protected virtual void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        _life = GetComponent<Life>();
        _animator = model.GetComponent<Animator>();
        _nav = GetComponent<NavMeshAgent>();

        _nav.stoppingDistance = distanceToAttack;
        _animator.SetFloat("Speed", 1f);

        _life.OnDie.AddListener(DeathFeedback);

        StartCoroutine(RoutineIA());
    }

    protected virtual IEnumerator RoutineIA()
    {
        while (!_life.isDead)
        {
            if (TargetDistance > distanceToAttack && TargetDistance < detectDistance)
            {
                _nav.SetDestination(target.position);
                _animator.SetBool("Move", true);
            }

            else if (TargetDistance <= distanceToAttack && canAttack)
            {
                canAttack = false;
                _animator.SetBool("Move", false);
                StartCoroutine(Attack());
            }

            else if (TargetDistance >= detectDistance)
            {
                _animator.SetBool("Move", false);
                _nav.SetDestination(transform.position);
            }

            yield return new WaitForSeconds(updateTargetPosition);
        }
    }


    protected virtual IEnumerator Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, distanceToAttack);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.transform != transform)
            {
                var life = hitCollider.gameObject.GetComponent<Life>();
                if (life != null)
                {
                    life.TakeDamage(damage);
                }
            }
        }

        yield return new WaitForSeconds(attackRate);

        canAttack = true;
    }

    protected virtual void DeathFeedback()
    {
        _nav.isStopped = true;
        _animator.SetBool("Move", false);
        Destroy(this.gameObject);
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToAttack);
    }
}
