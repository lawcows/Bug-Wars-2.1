using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Waves : MonoBehaviour
{
    public GameObject [] waves;
    public TextMeshProUGUI waveText;
    public Animator waveAnimator;
    int waveIndex = 0;
    float [] spawnTime;
    public float time = 5;
    void Start()
    {
        waves[0].SetActive(true);
        StartCoroutine(NextWave());
        waveText.text = "Wave " + (waveIndex + 1).ToString();
    }

    IEnumerator NextWave()
    {
        yield return new WaitForSecondsRealtime(time);
        waveIndex++;
        waves[waveIndex].SetActive(true);
        waveText.text = "Wave " + (waveIndex + 1).ToString();
        waveAnimator.SetTrigger("alerta");
        waves[(waveIndex - 1)].SetActive(false);
        if(waveIndex < waves.Length)
        StartCoroutine(NextWave());
    }

    private void Update() {
}

}
