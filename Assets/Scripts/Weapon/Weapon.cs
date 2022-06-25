using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    public Transform pipe;
    public float fireRate = 0.25f;

    [Header("Projectile Settings")]
    public Rigidbody bullet;
    public float bulletSpeed = 900f;

    protected bool canFire;

    protected virtual void Start() 
    {
        canFire = true;
    }

    protected virtual void FixedUpdate()
    {
        if (PauseMenu.Instance.IsPaused) return;

        if (canFire)
        {
            canFire = false;
            Rigidbody spawBullet = Instantiate(bullet, pipe.position, pipe.rotation);
            spawBullet.AddForce(pipe.forward * bulletSpeed);
            Invoke("FireRate", fireRate);
        }
    }

    protected virtual void FireRate()
    {
        canFire = true;
    }
}
