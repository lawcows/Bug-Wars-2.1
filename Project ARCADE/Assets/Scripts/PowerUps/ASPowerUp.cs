using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASPowerUp : MonoBehaviour
{
    Shoot shoot;
    bool used = false;
private void Start() {
    shoot = GameObject.Find("Player").GetComponent<Shoot>();
}


private void OnTriggerEnter(Collider other) {
    if(!used)
    {
    Debug.Log("ouch");
    shoot.fireRate++;
    used = true;
    Destroy(gameObject);
    }
}
}
