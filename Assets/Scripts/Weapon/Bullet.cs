using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;

    [SerializeField] private float destroyTime = 1.2f;
    [SerializeField] private float bulletDamage = 20f;

    [SerializeField] private bool canDamagePlayer = true;

    protected virtual void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    public void SetDamage(int value)
    {
        bulletDamage = value;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            if (other.gameObject.CompareTag("Player") && !canDamagePlayer) return;
            
            var life = other.gameObject.GetComponent<Life>();

            if (life != null)
            {
                life.TakeDamage(bulletDamage);
            }

            Destroy(this.gameObject);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            Destroy(this.gameObject);
        }
    }
}
