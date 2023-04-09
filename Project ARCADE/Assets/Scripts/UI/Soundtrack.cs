using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    public AudioSource soundtrack;

    private void Start() {
        soundtrack.GetComponent<AudioSource>().Play();   
    }
}