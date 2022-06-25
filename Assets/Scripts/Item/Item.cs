using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 2)]
public abstract class Item : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public ItemType type;

    [Space] public UnityEvent OnUserItem;

    public virtual void IncrementAction()
    {
        OnUserItem?.Invoke();
    }

    public enum ItemType
    {
        Consumable,
        Weapon,
    }
}
