using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Material", menuName = "ScriptableObjects/CraftItem", order = 3)]
public class CraftItem : Item
{
    [Header("Material")]
    public ItemType itemType;
    public int incrementAmount = 1;

    public override void IncrementAction()
    {
        OnUserItem?.Invoke();

        if (itemType == ItemType.Wood)
            InventoryCraft.i.Wood += incrementAmount;

        if (itemType == ItemType.Metal)
            InventoryCraft.i.Metal += incrementAmount;

        if (itemType == ItemType.Weapon)
            InventoryCraft.i.Weapon += incrementAmount;
    }
}
