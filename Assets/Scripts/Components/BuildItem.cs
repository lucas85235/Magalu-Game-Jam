using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InteractButton))]

public class BuildItem : MonoBehaviour
{
    protected InteractButton interact;

    [Header("Settings")]
    public GameObject notConstructedObject;
    public GameObject constructedObject;
    public int necessaryWood = 1;
    public int necessaryMetal = 1;

    [Header("UI")]
    public Text woodText;
    public Text metalText;

    protected void Start()
    {
        interact = GetComponent<InteractButton>();

        notConstructedObject.SetActive(true);
        constructedObject.SetActive(false);

        InventoryCraft.Instance.OnUpdateItems.AddListener(UpdateHud);
        interact.OnInteract.AddListener(OnInteract);

        UpdateHud();
    }

    protected void OnInteract()
    {
        interact.interactOption.SetActive(true);
        if (InventoryCraft.Instance.Wood < necessaryWood) return;
        if (InventoryCraft.Instance.Metal < necessaryMetal) return;
        interact.interactOption.SetActive(false);

        InventoryCraft.Instance.Wood -= necessaryWood;
        InventoryCraft.Instance.Metal -= necessaryMetal;

        interact.canInteract = false;
        notConstructedObject.SetActive(false);
        constructedObject.SetActive(true);
    }

    private void UpdateHud()
    {
        woodText.text = InventoryCraft.Instance.Wood + "/" + necessaryWood;
        metalText.text = InventoryCraft.Instance.Metal + "/" + necessaryMetal;
    }
}
