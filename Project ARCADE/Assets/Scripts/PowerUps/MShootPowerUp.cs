using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MShootPowerUp : MonoBehaviour
{
    Shoot shoot;
    bool used = false;
    public AudioSource collectSound;
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
        if(shoot.multishoot == 2 && !SelectPlayer.greenPlayerSelected)
        {
        shoot.SecondRedShoot();
        }  
        else if(shoot.multishoot == 3 && !SelectPlayer.greenPlayerSelected)
        {
            shoot.ThirdRedShoot();
        }
        collectSound.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, 3);
        used = true;
    }
}
}

