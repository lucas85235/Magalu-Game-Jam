using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryCraft : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private List<SerializeItems> serializeItems;

    private Dictionary<ItemType, int> items = new Dictionary<ItemType, int>();
    public Dictionary<ItemType, int> Inventory
    {
        get => items;
        private set => items = value;
    }

    public int Wood
    {
        get => Inventory[ItemType.Wood];
        set
        {
            Inventory[ItemType.Wood] = value;
            OnUpdateItems?.Invoke();
        }
    }

    public int Metal
    {
        get => Inventory[ItemType.Metal];
        set
        {
            Inventory[ItemType.Metal] = value;
            OnUpdateItems?.Invoke();
        }
    }

    public int Weapon
    {
        get => Inventory[ItemType.Weapon];
        set
        {
            Inventory[ItemType.Weapon] = value;
            OnUpdateItems?.Invoke();
        }
    }

    public UnityEvent OnUpdateItems;

    public static InventoryCraft i;

    void Awake()
    {
        i = this;

        foreach (ItemType item in Enum.GetValues(typeof(ItemType)))
        {
            items.Add(item, 0);
        }
    }

    private void Start()
    {

    }

#if UNITY_EDITOR

    private void FixedUpdate()
    {
        UpdateSerializeItems();
    }

#endif

    private void UpdateSerializeItems()
    {
        serializeItems = new List<SerializeItems>();

        foreach (var item in items)
        {
            serializeItems.Add(new SerializeItems(item.Key, item.Value));
        }
    }


}

[System.Serializable]
public struct SerializeItems
{
    public ItemType itemType;
    public int amount;

    public SerializeItems(ItemType itemType, int amount)
    {
        this.itemType = itemType;
        this.amount = amount;
    }
}

public enum ItemType
{
    Wood,
    Metal,
    Weapon,
}
