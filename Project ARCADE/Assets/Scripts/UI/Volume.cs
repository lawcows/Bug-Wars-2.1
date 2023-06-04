using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
[SerializeField] AudioMixer audioMixer;
public Slider volumeSlider;

private void Start() {
}
public void VolumeChange()
{
    audioMixer.SetFloat("Volume", volumeSlider.value);
}
}
