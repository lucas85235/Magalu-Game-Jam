using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    [Header("Item Pick")]
    public Item itemPick;
    
    protected InteractButton interactOption;

    protected virtual void Start() 
    {
        interactOption = GetComponent<InteractButton>();

        interactOption.OnInteract = () =>
        {            
            Inventory.Instance.AddItem(itemPick);

            if (itemPick.type == Item.ItemType.Weapon)
            {
                itemPick.IncrementAction();
            }

            Destroy(gameObject);
        };
    }
}
