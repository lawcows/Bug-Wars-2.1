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
    }

public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
