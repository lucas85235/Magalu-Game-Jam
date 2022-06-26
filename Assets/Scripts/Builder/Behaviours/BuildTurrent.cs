using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTurrent : BuildItem
{
    [Header("Settings")]
    public GameObject notConstructedObject;
    public GameObject constructedObject;

    [Header("UI")]
    public Text woodText;
    public Text metalText;

    protected override void Start()
    {
        base.Start();

        notConstructedObject.SetActive(true);
        constructedObject.SetActive(false);
    }

    protected override void OnInteract()
    {
        interact.interactOption.SetActive(true);

        foreach (var item in necessaryItems)
        {
            if (InventoryCraft.i.Inventory[item.itemType] < item.amount) return;
        }
        
        interact.interactOption.SetActive(false);

        InventoryCraft.i.Wood -= necessaryItems[0].amount;
        InventoryCraft.i.Metal -= necessaryItems[1].amount;

        interact.canInteract = false;
        notConstructedObject.SetActive(false);
        constructedObject.SetActive(true);
    }

    protected override void UpdateHud()
    {
        woodText.text = InventoryCraft.i.Wood + "/" + necessaryItems[0].amount;
        metalText.text = InventoryCraft.i.Metal + "/" + necessaryItems[1].amount;
    }
}
