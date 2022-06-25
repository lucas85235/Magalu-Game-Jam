using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTime = 1.2f;
    public float bulletDamage = 20f;

    protected virtual void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            var life = other.gameObject.GetComponent<Life>();

            if (life != null)
            {
                life.SetLife(-bulletDamage);
            }

            Destroy(this.gameObject);
        }
    }
}
