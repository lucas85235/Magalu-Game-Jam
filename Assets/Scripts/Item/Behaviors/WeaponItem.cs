using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/WeaponItem", order = 2)]
public class WeaponItem : Item
{
    [Header("Weapon")]
    public Weapon weapon;
}
