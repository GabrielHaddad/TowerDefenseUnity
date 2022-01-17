using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    TowerInput towerInput;
    [SerializeField] GameObject pauseMenu;

    void Awake() 
    {
        towerInput = new TowerInput();
    }

    void OnEnable()
    {
        towerInput.Enable();
    }

    void OnDisable()
    {
        towerInput.Disable();
    }

    void Start() 
    {
        towerInput.Keyboard.Pause.performed += _ => PauseClick();
    }

    void PauseClick()
    {
        if (!gameIsPaused)
        {
            Pause();
        }
    }

    public void ResumeClick()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
