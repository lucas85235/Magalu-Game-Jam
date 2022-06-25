using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Makes the object permament acroso scenes.
@Author: Gabriel de Mello.
*/
public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
    }
}
