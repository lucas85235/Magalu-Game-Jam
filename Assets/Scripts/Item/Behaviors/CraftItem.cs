using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Material", menuName = "ScriptableObjects/CraftItem", order = 3)]
public class CraftItem : Item
{
    [Header("Material")]
    public InventoryCraft.ItemType itemType;
    public int incrementAmount = 1;

    public override void IncrementAction()
    {
        OnUserItem?.Invoke();
        InventoryCraft.Instance.Inventory[itemType] += incrementAmount;
    }
}
