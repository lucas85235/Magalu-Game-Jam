using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/WeaponItem", order = 2)]
public class WeaponItem : Item
{
    [Header("Weapon")]
    public Weapon weapon;

    [Header("Adjust Spaw")]
    public Vector3 positionOffset = new Vector3(0, 0, 0);
    public Vector3 rotationOffset = new Vector3(0, 90, 0);
}
