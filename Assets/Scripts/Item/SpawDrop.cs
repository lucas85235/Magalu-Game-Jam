using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawDrop : MonoBehaviour
{
    public Drop drop;
    public Vector2Int spawTime = new Vector2Int(4, 8);

    private Life player;
    private Collider col;

    private IEnumerator Start()
    {
        player = FindObjectOfType<Player>().life;
        col = GetComponent<Collider>();

        while (!player.isDead)
        {
            var time = Random.Range(spawTime.x, spawTime.y);
            yield return new WaitForSeconds(time);

            Vector3 pos = RandomPosition();

            var d = Instantiate(drop);
            d.transform.position = pos;
        }
    }

    private Vector3 RandomPosition()
    {
        var px = Random.Range(col.bounds.min.x, col.bounds.max.x);
        var py = Random.Range(col.bounds.min.z, col.bounds.max.z);

        return new Vector3(px, 10, py);
    }
}
