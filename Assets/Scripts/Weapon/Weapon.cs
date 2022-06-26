using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    public WeaponItem info;    
    public Transform pipe;
    public float fireRate = 0.25f;

    [Header("Projectile Settings")]
    public Bullet bullet;
    public float bulletSpeed = 900f;

    protected bool canFire;

    [HideInInspector]
    public Player user;

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
            Bullet spawBullet = Instantiate(bullet, pipe.position, pipe.rotation);
            spawBullet.SetDamage(info.damage + user.bonusDamage);
            spawBullet.rb.AddForce(pipe.forward * bulletSpeed);
            
            Invoke("FireRate", fireRate);
        }
    }

    public virtual void ItemInfo(WeaponItem value)
    {
        info = value;

        // Debug.Log("W value " + value);
        // Debug.Log("W damage " + damage);
    }

    protected virtual void FireRate()
    {
        canFire = true;
    }
}
