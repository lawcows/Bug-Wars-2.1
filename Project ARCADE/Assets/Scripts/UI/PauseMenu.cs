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
        else if(Boss2.boss2Defeated)
        {
            winScreen.SetActive(true);
        }
        else if(Boss33.boss33Defeated)
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
        SceneManager.LoadScene("Intro");
    }

    //Fecha o jogo
    public void QuitGame()
    {
        Application.Quit();
    }    
}