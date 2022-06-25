using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Inventory")]
    public GameObject slot;
    public int slotAmount = 8;
    public Text itemDescription;
    public RectTransform container;

    [Header("Items List")]
    public List<Item> items = new List<Item>();
    public List<Image> slots = new List<Image>();

    public GameObject mouseItem;

    public static Inventory Instance;

    protected virtual void Awake() 
    {
        Instance = this;

        slots.Add(slot.transform.GetChild(0).GetComponent<Image>());
        slots[0].name = "0";

        for (int i = 0; i < slotAmount - 1; i++)
        {
            var temp = Instantiate(slot);
            temp.transform.SetParent(container);
            slots.Add(temp.transform.GetChild(0).GetComponent<Image>());
            slots[i + 1].name = (i + 1).ToString();
        }
    }

    public virtual void AddItem(Item item)
    {
        if (InventoryItemsLenght() + 1 < slotAmount)
        {
            var nextSlot = NextEmptySlot();

            if (nextSlot > -1)
            {
                // Debug.Log(nextSlot + "");

                items.Add(item);
                slots[nextSlot].sprite = item.itemSprite;
            }
        }
        else Debug.Log("Inventory Full");
    }

    protected virtual int InventoryItemsLenght()
    {
        int lenght = -1;

        for (int i = 0; i < items.Count; i++)
        {
            lenght++;
        }

        return lenght;
    }

    protected virtual int NextEmptySlot()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].sprite == null)
            {
                // Debug.Log("Find Empty Slot " + i);
                return i;
            }
        }

        return -1;
    }

    public virtual void SelectItem(GameObject button)
    {
        if (button.TryGetComponent(out Image image))
        {
            if (image.sprite == null) return;
        }

        var item = items[int.Parse(button.name)];
        itemDescription.text = item.itemName + ": " + item.itemDescription;
    }

    public void DragItem (GameObject button)
    {
        if (button.TryGetComponent(out Image image))
        {
            if (image.sprite == null) return;
        }
       
        mouseItem = button;
        mouseItem.transform.position = Input.mousePosition;

    }

    public void DropItem (GameObject button)
    {
        if (mouseItem != null)
        {
            Transform temp = mouseItem.transform.parent;
            mouseItem.transform.SetParent(button.transform.parent);
            button.transform.SetParent(temp);
        }
    }
}
