using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    [SerializeField] Transform EBulletSpawner;
    float nextTimeToShoot;
    public float fireRate = 1;
    public bool canfire = true;

    private void Start()
    {

    }

    public void Update()
    {
        if (canfire)
            StartCoroutine(GunShoot());


    }
    IEnumerator GunShoot()
    {
        canfire = false;
        GameObject temporaryBall;
        temporaryBall = Instantiate(enemyBullet, EBulletSpawner.transform.position, enemyBullet.transform.rotation) as GameObject;
        Rigidbody temporaryBallRB;
        temporaryBallRB = temporaryBall.GetComponent<Rigidbody>();
        temporaryBallRB.AddForce(EBulletSpawner.transform.forward);
        Destroy(temporaryBall, 50);
        nextTimeToShoot = Time.time;
        StartCoroutine(FireRateHandler());       
        yield return null;

       
        IEnumerator FireRateHandler()
        {
            float nextTimeToShoot = 1 / fireRate;
            yield return new WaitForSecondsRealtime(nextTimeToShoot);
            canfire = true;
        }
    }
}