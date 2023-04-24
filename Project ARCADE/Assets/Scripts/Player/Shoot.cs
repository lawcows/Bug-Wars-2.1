using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot: MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawner;
    float nextTimeToShoot;
    public float fireRate = 1;
    public float bulletDamage;
    public bool canfire = true;
    public AudioSource shootSound;

    private void Start() {

    }

public void Update() 
{
    if(canfire)
    StartCoroutine(GunShoot());
    

}
    IEnumerator GunShoot()
{
    if(Input.GetKey(KeyCode.Mouse0))
    {  
            canfire = false;
            GameObject temporaryBall;
            temporaryBall = Instantiate(bullet, bulletSpawner.transform.position, bullet.transform.rotation) as GameObject;
            Rigidbody temporaryBallRB;
            temporaryBallRB = temporaryBall.GetComponent<Rigidbody>();
            temporaryBallRB.AddForce(bulletSpawner.transform.forward);   
            Destroy(temporaryBall, 5f);
            nextTimeToShoot = Time.time;
            StartCoroutine(FireRateHandler());
            shootSound.GetComponent<AudioSource>().Play();
            yield return null;
    }
    IEnumerator FireRateHandler()
    {
        float nextTimeToShoot = 1 / fireRate;
        yield return new WaitForSecondsRealtime(nextTimeToShoot);
        canfire = true;
    }
}
}