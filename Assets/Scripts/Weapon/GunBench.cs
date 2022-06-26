using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunBench : BuildItem
{
    [Header("UI")]
    public Text pistolWeapon;
    public Text metalText;
    public GameObject canvas;

    [Header("Weapons")]
    public List<WeaponItem> weapons;
    public int currentIndex = 0;

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

        InventoryCraft.i.Weapon -= necessaryItems[0].amount;
        InventoryCraft.i.Metal -= necessaryItems[1].amount;

        interact.interactOption.SetActive(false);
        handle.SetWeapon(weapons[currentIndex]);

        if (currentIndex + 1 < weapons.Count)
        {
            currentIndex++;

            for (int i = 0; i < necessaryItems.Count; i++)
            {
                var item = necessaryItems[i];
                item.amount *= 2;

                necessaryItems[i] = item;
            }

            UpdateHud();
        }
        else 
        {
            interact.canInteract = false;
            canvas.SetActive(false);
        }
    }

    protected override void UpdateHud()
    {
        pistolWeapon.text = InventoryCraft.i.Weapon + "/" + necessaryItems[0].amount;
        metalText.text = InventoryCraft.i.Metal + "/" + necessaryItems[1].amount;
    }
}
