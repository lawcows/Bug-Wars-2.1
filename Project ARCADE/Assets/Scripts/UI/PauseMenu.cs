using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject winScreen;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();         
            }
            else
            {
                Pause();
            }
        }

        if(Boss1.boss1Defeated)
        {
            winScreen.SetActive(true);
        }
    }

    //Retorna ao jogo    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Pausa o jogo
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //Carrega Menu inicial
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Fecha o jogo
    public void QuitGame()
    {
        Application.Quit();
    }    
}