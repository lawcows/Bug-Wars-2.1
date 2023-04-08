using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
[SerializeField] AudioListener audioListener;
[SerializeField] GameObject volumeON;
[SerializeField] GameObject volumeOff;
    void Start()
    {
    volumeON.SetActive(true);
    volumeOff.SetActive(false);
    }

public void VolumeOff()
{
    audioListener.enabled = false;
    volumeON.SetActive(false);
    volumeOff.SetActive(true);
}
public void VolumeOn()
{
    audioListener.enabled = true;
    volumeON.SetActive(true);
    volumeOff.SetActive(false);
}
}
