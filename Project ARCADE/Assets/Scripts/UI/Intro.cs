using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(ChageToMenu());
    }

    IEnumerator ChageToMenu()
    {
        yield return new WaitForSecondsRealtime(3.5f);
        SceneManager.LoadScene("Menu");
    }
}
