using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MShootPowerUp : MonoBehaviour
{
    Shoot shoot;
    bool used = false;
private void Start() {
    shoot = GameObject.Find("Player").GetComponent<Shoot>();
    if(shoot.multishoot >= 3)
    {
        Destroy(gameObject);
    }
}

private void OnTriggerEnter(Collider other) {
    if(!used)
    {
        shoot.multishoot++;
        if(shoot.multishoot == 2)
        {
        shoot.SecondRedShoot();
        }  
        else if(shoot.multishoot == 3)
        {
            shoot.ThirdRedShoot();
        }
        Destroy(gameObject);
    }
}
}

