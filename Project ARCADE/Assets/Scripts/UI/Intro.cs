using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(ChageToMenu());
    }

    IEnumerator ChageToMenu()
    {
        yield return new WaitForSecondsRealtime(3.5f);
        SceneManager.LoadScene("Menu");
    }
}
