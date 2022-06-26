using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InteractButton))]

public class BuildItem : MonoBehaviour
{
    [Space]
    public List<SerializeItems> necessaryItems;

    protected InteractButton interact;

    protected virtual void Start()
    {
        interact = GetComponent<InteractButton>();

        interact.OnInteract.AddListener(OnInteract);
        InventoryCraft.i.OnUpdateItems.AddListener(UpdateHud);

        UpdateHud();
    }

    protected virtual void OnInteract()
    {
        interact.canInteract = false;
    }

    protected virtual void UpdateHud()
    {
        
    }
}
