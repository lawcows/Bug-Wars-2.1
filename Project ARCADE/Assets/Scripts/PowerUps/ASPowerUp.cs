using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASPowerUp : MonoBehaviour
{
    Shoot shoot;
    rBullet [] redBullet;
    bool used = false;
private void Start() {
    shoot = GameObject.Find("Player").GetComponent<Shoot>();
    redBullet = GameObject.Find("Player").GetComponentsInChildren<rBullet>();
    if(shoot.fireRate >= 3)
    {
        Destroy(gameObject);
    }
}


private void OnTriggerEnter(Collider other) {
    if(!used )
    {
        if(shoot.greenShoot)
        {
            shoot.fireRate++;

        }
        else if (shoot.redShoot)
        {
            for(int i = 0; i < redBullet.Length; i++)
            {
            redBullet[i].bulletSpeed += 3;
            }
        }
    used = true;
    Destroy(gameObject);
    }

}
}
