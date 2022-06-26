using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public List<ItemPick> items;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            var r = Random.Range(0, items.Count);
            var spawItem = Instantiate(items[r].gameObject);
            spawItem.transform.position = other.contacts[0].point + Vector3.up;
            Destroy(gameObject);
        }
        else Destroy(gameObject);
    }
}
