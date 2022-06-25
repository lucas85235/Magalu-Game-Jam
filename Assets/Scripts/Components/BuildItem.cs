using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractButton))]

public class BuildItem : MonoBehaviour
{
    protected InteractButton interact;

    [Header("Settings")]
    public GameObject notConstructedObject;
    public GameObject constructedObject;

    protected void Start()
    {
        interact = GetComponent<InteractButton>();

        notConstructedObject.SetActive(true);
        constructedObject.SetActive(false);

        interact.OnInteract.AddListener(OnBuild);
    }

    protected void OnBuild()
    {
        interact.canInteract = false;
        notConstructedObject.SetActive(false);
        constructedObject.SetActive(true);
    }
}
