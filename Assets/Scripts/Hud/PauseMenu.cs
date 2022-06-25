using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject mainManu;
    public bool IsPaused;

    public static PauseMenu Instance;
    private PlayerCharControls inputActions;

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        }

        inputActions = new PlayerCharControls();

        inputActions.Interface.Pause.performed += _ => PauseUnpause();
    }

    private void OnEnable()
    {
        inputActions.Enable();   
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void PauseUnpause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0 : 1;
        mainManu.SetActive(IsPaused);
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
