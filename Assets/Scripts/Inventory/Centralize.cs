using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centralize : MonoBehaviour
{    
    protected virtual void Update()
    {
        transform.position += (transform.parent.position - transform.position) * 5 * Time.unscaledDeltaTime;
    }
}
