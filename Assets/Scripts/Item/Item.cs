using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public abstract class Item : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;

    [Space] 
    [Header("Events")]
    public UnityEvent OnUserItem;

    public virtual void IncrementAction()
    {
        OnUserItem?.Invoke();
    }
}
