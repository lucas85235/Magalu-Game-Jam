using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ActivationCallback : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEnable;
    [SerializeField] private UnityEvent _onDisable;

    private UnityEvent onEnable { get => _onEnable; }
    private UnityEvent onDisable { get => _onDisable; }
    
    private void OnEnable() 
    {
        onEnable?.Invoke();
    }
    
    private void OnDisable() 
    {
        onDisable?.Invoke();
    }
}
