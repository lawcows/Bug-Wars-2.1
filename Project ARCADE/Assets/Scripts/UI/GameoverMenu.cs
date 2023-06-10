using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameoverMenu : MonoBehaviour
{
    [SerializeField] string gameSceneName;
    [SerializeField] string menuSceneName;
    [SerializeField] string playerSelectionSceneName;

    private void Start() {
        Time.timeScale = 0.2f;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(gameSceneName);
        Time.timeScale = 1;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
        Time.timeScale = 1;
    }

    public void PlayerSelection()
    {
        SceneManager.LoadScene(playerSelectionSceneName);
        Time.timeScale = 1;
        Boss1.boss1Defeated = false;
        Boss2.boss2Defeated = false;
        Boss33.boss33Defeated = false;
    }

}
