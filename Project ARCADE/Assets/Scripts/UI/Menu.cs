using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
[SerializeField] GameObject startMenu;
[SerializeField] GameObject settingsMenu;

private void Start() {
    startMenu.SetActive(true);
    settingsMenu.SetActive(false);
}

public void Settings()
{
    startMenu.SetActive(false);
    settingsMenu.SetActive(true);
}

public void BackButton()
{
    startMenu.SetActive(true);
    settingsMenu.SetActive(false);
}
public void StartGame()
{
StartCoroutine(StartGameCRT());
}

IEnumerator StartGameCRT()
{
    yield return new WaitForSecondsRealtime(1);
    SceneManager.LoadScene("Selection");
}
}
