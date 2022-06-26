using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [Header("Weapon")]
    public Text weapon;
    
    [Header("Life")]
    public Slider life;

    public static HudManager Instance;

    protected virtual void Awake() 
    {
        Instance = this;
        
        SetWeaponHud("WEAPON", 0);
    }

    public virtual void SetWeaponHud(string weaponName, int weaponBullets)
    {
        weapon.text = weaponName + " - " + weaponBullets;
    }

    public virtual void SeLifeHud(float currentLife, float maxLife)
    {
        life.maxValue = maxLife;
        life.value = currentLife;
    }
}
