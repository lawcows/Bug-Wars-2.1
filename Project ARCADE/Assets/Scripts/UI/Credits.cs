using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{

    public Canvas creditCanvas;
    public GameObject creditText;
    public float scrollSpeed = 50f;


    void Start()
    {
        
    }


    void Update()
    {
        creditText.transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
    }
}
