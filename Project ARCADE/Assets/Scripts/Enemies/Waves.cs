using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public GameObject [] waves;
    int waveIndex;
    float [] spawnTime;
    public float time = 5;
    void Start()
    {
        waves[0].SetActive(true);
        StartCoroutine(NextWave());
    }

    IEnumerator NextWave()
    {
        yield return new WaitForSecondsRealtime(time);
        waveIndex++;
        waves[waveIndex].SetActive(true);
        waves[(waveIndex - 1)].SetActive(false);
        StartCoroutine(NextWave());
    }

    private void Update() {
    Debug.Log(Time.time);
}

}
