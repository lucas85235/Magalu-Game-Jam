using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    protected Life _life;
    protected NavMeshAgent _nav;
    protected ZombieAnimations _animations;
    protected bool canAttack = true;

    [Header("Enemy")]
    public Transform model;
    public float destroyTime = 2f;

    [Header("Target Setup")]
    public Transform target;
    public float distanceToAttack = 2f;
    public float updateTargetPosition = 1f;

    [Header("Enemy Status")]
    public float damage = 10f;
    public float attackRate = 1f;
    public float damageDelay = 0.4f;

    [Header("Enemy")]
    public PlayClips audioIdle;
    public PlayClips audioAttack;

    private float idleSoundDelay = 3;

    public float TargetDistance => Vector3.Distance(transform.position, target.position);

    protected virtual void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        _life = GetComponent<Life>();
        _animations = model.GetComponent<ZombieAnimations>();
        _nav = GetComponent<NavMeshAgent>();
        GetComponent<Collider>().enabled = true;

        _nav.enabled = true;
        _nav.stoppingDistance = distanceToAttack;
        _animations.Walk(1f);

        _life.OnDie.AddListener(DeathFeedback);

        StartCoroutine(RoutineIA());
        StartCoroutine(IdleSounds());
    }

    private void LateUpdate()
    {
        if (!_life.isDead && !canAttack)
        {
            transform.LookAt(target.position);
        }
    }

    protected virtual IEnumerator RoutineIA()
    {
        while (!_life.isDead && target != null)
        {
            if (TargetDistance > distanceToAttack && canAttack)
            {
                if (!_nav.enabled)
                    _nav.enabled = true;

                _nav.SetDestination(target.position);
                _animations.Walk(1f);
            }

            else if (TargetDistance <= distanceToAttack && canAttack)
            {
                canAttack = false;
                _animations.Attack();

                StartCoroutine(Attack());
            }

            yield return new WaitForSeconds(updateTargetPosition);
        }
    }

    private IEnumerator IdleSounds()
    {
        while (true)
        {
            if (_life.isDead) yield break;

            if (canAttack)
            {
                SoundManager.Instance.PlayClip("ZombieGrowl");
            }
            yield return new WaitForSeconds(idleSoundDelay);
        }
    }

    protected virtual IEnumerator Attack()
    {
        yield return new WaitForSeconds(damageDelay);

        SoundManager.Instance.PlayClip("ZombieAttack");
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

        yield return new WaitForSeconds(attackRate - damageDelay);

        canAttack = true;
    }

    protected virtual void DeathFeedback()
    {
        if (_nav.enabled) 
            _nav.isStopped = true;
            
        _animations.Death();
        Destroy(this.gameObject, destroyTime);
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToAttack);
    }
}
