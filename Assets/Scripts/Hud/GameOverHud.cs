using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHud : MonoBehaviour
{
    public GameObject hud;

    protected Life playerLife;

    void Start()
    {
        playerLife = FindObjectOfType<Player>().life;
        playerLife.OnDie.AddListener(ActiveGameOverHud);
    }

    public void ActiveGameOverHud()
    {
        hud.SetActive(true);
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
