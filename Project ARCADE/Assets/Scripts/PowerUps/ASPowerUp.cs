using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASPowerUp : MonoBehaviour
{
    public Shoot shoot;
    bool used = false;
private void Start() {
    
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
