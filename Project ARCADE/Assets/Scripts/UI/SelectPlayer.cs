using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour
{
    public static bool redPlayerSelected = false;
    public static bool greenPlayerSelected = false;
    public static bool fusionPlayerSelected = false;
    public GameObject startButton, gPButton, rPButton;
    public TextMeshProUGUI choseYourBug;
    string nextSceneToLoad;

    private void Start() {
        startButton.SetActive(true);
        if(nextSceneToLoad == null)
        {
            nextSceneToLoad = "Level 1";
        }
    }
    public void GreenPlayerSelect()
    {
        greenPlayerSelected = true;
        redPlayerSelected = false;
        fusionPlayerSelected = false;
        StartCoroutine(StartGame());
    }

    public void RedPlayerSelect()
    {
        redPlayerSelected = true;
        greenPlayerSelected = false;
        fusionPlayerSelected = false;
        StartCoroutine(StartGame());
    }

    public void FusionSelected()
    {
        fusionPlayerSelected = true;
        redPlayerSelected = false;
        greenPlayerSelected = false;
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
