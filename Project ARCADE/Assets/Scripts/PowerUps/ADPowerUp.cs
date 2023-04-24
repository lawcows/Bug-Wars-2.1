using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADPowerUp : MonoBehaviour
{
    Shoot shoot;
    bool used = false;
    public float increase = 10f;
private void Start() {
    shoot = GameObject.Find("Player").GetComponent<Shoot>();
}


private void OnTriggerEnter(Collider other) {
    if(!used)
    {
    Debug.Log("ouch");
    shoot.bulletDamage = shoot.bulletDamage + increase;
    used = true;
    Destroy(gameObject);
    }
}
}

