using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractButton : MonoBehaviour
{
    [Space]
    public UnityEvent OnInteract;

    [HideInInspector]
    public bool canInteract = true;

    [Header("Interact Button")]
    public GameObject interactOption;
    public Vector3 adjustLocalPosition = Vector3.zero;

    protected void Start()
    {
        interactOption = Instantiate(interactOption);
        interactOption.transform.SetParent(transform);
        interactOption.transform.localPosition = adjustLocalPosition;
        interactOption.SetActive(false);
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactOption.activeSelf && canInteract)
        {
            interactOption.SetActive(false);
            OnInteract?.Invoke();
        }
    }

    protected virtual void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" && !interactOption.activeSelf && canInteract)
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
