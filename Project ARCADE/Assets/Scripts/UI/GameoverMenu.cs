using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameoverMenu : MonoBehaviour
{
    [SerializeField] string gameSceneName;
    [SerializeField] string menuSceneName;

    public void TryAgain()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

}
