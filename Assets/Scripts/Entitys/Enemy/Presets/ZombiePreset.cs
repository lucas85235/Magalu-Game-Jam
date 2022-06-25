using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombiePreset", menuName = "ScriptableObjects/ZombiePreset", order = 1)]
public class ZombiePreset : ScriptableObject
{
    [Header("Preset")]
    public string zombieName;
    public int hp = 10;
    public int damge = 5;
    public float cooldown = 2f;
    public float speed = 2f;
}
