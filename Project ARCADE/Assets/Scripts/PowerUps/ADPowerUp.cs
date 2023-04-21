using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADPowerUp : MonoBehaviour
{
    public Bullet bullet;
    bool used = false;
    public float increase = 10f;
private void Start() {
    
}


private void OnTriggerEnter(Collider other) {
    if(!used)
    {
    Debug.Log("ouch");
    bullet.bullet1Damage = bullet.bullet1Damage + increase;
    used = true;
    Destroy(gameObject);
    }
}
}

