using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessingScript : MonoBehaviour
{
private void Awake() {
        GameObject[] postProcessing = GameObject.FindGameObjectsWithTag("postprocessing");
        if(postProcessing.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
}
}
