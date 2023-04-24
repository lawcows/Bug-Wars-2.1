using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalPowerUp : MonoBehaviour
{
    Shoot shoot;
    bool used = false;
private void Start() {
    shoot = GameObject.Find("Player").GetComponent<Shoot>();
    int r = Random.Range(0,5);
}


private void OnTriggerEnter(Collider other) {
    if(!used)
    {
    Debug.Log("ouch");
    Destroy(gameObject);
    }
}
}

