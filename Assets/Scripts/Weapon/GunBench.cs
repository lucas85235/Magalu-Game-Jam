using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunBench : BuildItem
{
    [Header("UI")]
    public Text pistolWeapon;
    public Text metalText;

    [Header("UI")]
    public List<WeaponItem> item;

    private WeaponHandle handle;

    protected override void Start()
    {
        base.Start();
        handle = FindObjectOfType<WeaponHandle>();
    }

    protected override void OnInteract()
    {

        interact.interactOption.SetActive(true);

        foreach (var item in necessaryItems)
        {
            if (InventoryCraft.i.Inventory[item.itemType] < item.amount) return;
        }
        
        interact.interactOption.SetActive(false);

        InventoryCraft.i.Weapon -= necessaryItems[0].amount;
        InventoryCraft.i.Metal -= necessaryItems[1].amount;

        interact.canInteract = false;
    }

    protected override void UpdateHud()
    {
        pistolWeapon.text = InventoryCraft.i.Weapon + "/" + necessaryItems[0].amount;
        metalText.text = InventoryCraft.i.Metal + "/" + necessaryItems[1].amount;
    }
}
