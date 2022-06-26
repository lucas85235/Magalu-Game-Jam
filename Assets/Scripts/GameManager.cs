using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;

    private PauseMenu pauseMenu;

    private void Awake()
    {
        Instance = this;

        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }

        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    public void ActivateUpgradePanel()
    {
        Time.timeScale = 0;
        pauseMenu.SetUpgradePanel(true);
    }

    public void UpgradeLife()
    {
        player.UpgradeLife();
        Time.timeScale = 1;
        pauseMenu.SetUpgradePanel(false);
    }
    public void UpgradeAttack()
    {
        player.UpgradeDamage();
        Time.timeScale = 1;
        pauseMenu.SetUpgradePanel(false);
    }
    public void UpgradeDefense()
    {
        player.UpgradeDefence();
        Time.timeScale = 1;
        pauseMenu.SetUpgradePanel(false);
    }
    public void UpgradeSpeed()
    {
        player.UpgradeVelocity();
        Time.timeScale = 1;
        pauseMenu.SetUpgradePanel(false);
    }
}
