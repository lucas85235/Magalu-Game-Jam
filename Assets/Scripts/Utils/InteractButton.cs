using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    public Action OnInteract;
    public bool canInteract { get => interactOption.activeSelf; }

    [Header("Interact Button")]
    public GameObject interactOption;
    public Vector3 adjustLocalPosition = Vector3.zero;

    void Start()
    {
        interactOption = Instantiate(interactOption);
        interactOption.transform.SetParent(transform);
        interactOption.transform.localPosition = adjustLocalPosition;
        interactOption.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            interactOption.SetActive(false);
            if (OnInteract != null) OnInteract();
        }
    }

    protected virtual void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" && !canInteract)
        {
            interactOption.SetActive(true);
        }   
    }

    protected virtual void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            interactOption.SetActive(false);
        }   
    }
}
