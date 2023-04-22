using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectPlayer : MonoBehaviour
{
    public static bool redPlayerSelected = false;
    public static bool greenPlayerSelected = false;
    public GameObject startButton;
    public TextMeshProUGUI choseYourBug;

    private void Start() {
        startButton.SetActive(false);
    }
    public void GreenPlayerSelect()
    {
        greenPlayerSelected = true;
        redPlayerSelected = false;
        startButton.SetActive(true);
        choseYourBug.enabled = false;
    }

    public void RedPlayerSelect()
    {
        greenPlayerSelected = false;
        redPlayerSelected = true;
        startButton.SetActive(true);
        choseYourBug.enabled = false;
    }
}
