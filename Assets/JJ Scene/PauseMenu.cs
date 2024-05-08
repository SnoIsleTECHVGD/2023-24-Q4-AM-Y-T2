using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public bool pausecheck;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject fadecanvas;


    void Update()
    {

        pausecheck = isGamePaused;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        fadecanvas.SetActive(true);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
       fadecanvas.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void LoadMenu()
    {
        isGamePaused = false;
        //SceneManager.LoadScene(0);
        //Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}