using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomActive : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;

    private void Start()
    {
        var rand = Random.Range(0, objects.Count);

        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(i == rand);
        }
    }
}
