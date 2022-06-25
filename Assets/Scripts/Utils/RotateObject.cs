using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Rotates an object around the specified axis.
@Author: Gabriel de Mello.
*/
public class RotateObject : MonoBehaviour
{
    [SerializeField] private bool _useUnscaledTime;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _axis;

    public bool useUnscaledTime { get => _useUnscaledTime; }
    public float speed { get => _speed; }
    
    public Vector3 axis { get => _axis; }

    void Start()
    {
        
    }

    void Update()
    {
        Rotate();
    }
    
    private void Rotate()
    {
        transform.rotation *= Quaternion.Euler(axis.normalized * speed * 
            (useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime));
    }
}
