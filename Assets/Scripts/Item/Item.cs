using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public abstract class Item : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public PickItem type;

    [Space] public UnityEvent OnUserItem;

    public virtual void IncrementAction()
    {
        OnUserItem?.Invoke();
    }

    public enum PickItem
    {
        Weapon,
        Craft,
    }
}
