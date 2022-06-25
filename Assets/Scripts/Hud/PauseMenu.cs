using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject mainManu;
    public bool IsPaused;

    public static PauseMenu Instance;

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            IsPaused = true;
            mainManu.SetActive(true);
        }
    }

    public void GameReturn()
    {
        mainManu.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1;
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void SetPause(bool state)
    {
        IsPaused = state;

        if (state)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;        
    }

    public void GameQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
