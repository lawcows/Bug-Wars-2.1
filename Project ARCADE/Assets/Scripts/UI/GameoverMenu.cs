using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameoverMenu : MonoBehaviour
{
    [SerializeField] string gameSceneName;
    [SerializeField] string menuSceneName;

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

}
