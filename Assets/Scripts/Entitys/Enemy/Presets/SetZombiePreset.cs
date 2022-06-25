using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetZombiePreset : MonoBehaviour
{
    public ZombiePreset preset;

    private void Awake()
    {
        GetComponent<Life>().maxLife = preset.hp;
        GetComponent<NavMeshAgent>().speed = preset.speed;
        GetComponent<NavMeshAgent>().acceleration = preset.speed;
        GetComponent<Enemy>().damage = preset.damge;
        GetComponent<Enemy>().attackRate = preset.cooldown;
    }
}
