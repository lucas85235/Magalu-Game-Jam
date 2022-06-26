using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SpawEnemys : MonoBehaviour
{
    [Header("Spaw Settings")]
    public List<Enemy> enemys;
    public Vector2Int spawTime = new Vector2Int(1, 2);
    public float spawDistance = 15f;

    [Header("Level Settings")]
    public int currentLevel = 1;
    public List<Level> levels;
    public Level level;

    [Header("Debug")]
    [SerializeField] private int deathEnemys = 0;
    [SerializeField] private int maxEnemys = 10;
    [SerializeField] private int levelEnemys = 10;
    [SerializeField] private List<GameObject> spawEnemys = new List<GameObject>();

    private Life player;
    private Collider col;

    // private void Awake()
    // {
    //     level = LevelSettings();
    //     maxEnemys = level.maxEnemys;
    //     levelEnemys = level.levelEnemys;        
    // }

    private void Start()
    {
        player = FindObjectOfType<Player>().life;
        col = GetComponent<Collider>();

        level = LevelSettings();
        maxEnemys = level.maxEnemys;
        levelEnemys = level.levelEnemys;

        Loop();
    }

    private async void Loop()
    {
        while (!player.isDead)
        {
            int time = Random.Range(spawTime.x, spawTime.y);
            await Task.Delay(time * 1000);

            // MAX ENEMYS
            if (spawEnemys.Count >= maxEnemys) continue;

            Vector3 pos = RandomPosition();
            
            while (player != null && Vector3.Distance(player.transform.position, pos) <= spawDistance)
            {
                pos = RandomPosition();
            }

            var d = Instantiate(enemys[Random.Range(0, RandIndex())]);
            d.transform.position = pos;

            spawEnemys.Add(d.gameObject);

            d.GetComponent<Life>().OnDie.AddListener(() =>
            {
                spawEnemys.Remove(d.gameObject);
                deathEnemys++;

                if (deathEnemys >= levelEnemys)
                {
                    LevelUp();
                }
            });            
        }
    }

    private void LevelUp()
    {
        deathEnemys = 0;
        currentLevel++;
        level = LevelSettings();
        maxEnemys = level.maxEnemys;
        levelEnemys = level.levelEnemys;
    }

    private Level LevelSettings()
    {
        var index = 0;

        if (currentLevel - 1 >= levels.Count)
            index = levels.Count - 1;
        else index = currentLevel - 1;

        return levels[index];
    }

    private int RandIndex()
    {
        var index = 0;

        if (currentLevel - 1 >= levels.Count)
            index = levels.Count - 1;
        else index = currentLevel - 1;

        if (index - 1 >= enemys.Count)
            index = enemys.Count - 1;

        return index;
    }

    private Vector3 RandomPosition()
    {
        var px = Random.Range(col.bounds.min.x, col.bounds.max.x);
        var py = Random.Range(col.bounds.min.z, col.bounds.max.z);

        return new Vector3(px, 1, py);
    }
}
