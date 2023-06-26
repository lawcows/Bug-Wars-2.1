using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRegion : MonoBehaviour
{
    private void OnTriggerExit(Collider other) {
        if( other.tag != "boss")
        Destroy(other.gameObject);
        
    }
}