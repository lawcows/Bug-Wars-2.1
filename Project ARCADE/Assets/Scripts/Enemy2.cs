using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
public float enemySpeed = 0.2f;
public GameObject bullet;
public Transform bulletSpawner;
Vector3 enemyMoveX = new Vector3 (1,0,0);
Vector3 enemyMoveZ = new Vector3 (0,0,-0.5f);
float nextShot;
public float fireRate;
public float enemy1HP = 100;
public float bulletDamage= 30;
private void Update() {
    transform.Translate(enemyMoveX * enemySpeed * Time.deltaTime);
    transform.Translate(enemyMoveZ * enemySpeed * Time.deltaTime);
    ShootPlayer();
}

    private void ShootPlayer()
    {
        if(Time.time > nextShot)
    {
        nextShot = Time.time + fireRate;
            GameObject temporaryBall;
            temporaryBall = Instantiate(bullet, bulletSpawner.transform.position, bullet.transform.rotation) as GameObject;
            Rigidbody temporaryBallRB;
            temporaryBallRB = temporaryBall.GetComponent<Rigidbody>();
            temporaryBallRB.AddForce(bulletSpawner.transform.forward);   
            Destroy(temporaryBall, 5f);
    }
    }

private void OnCollisionEnter(Collision other) {
    GetHitted();
}
void GetHitted()
{
    enemy1HP = enemy1HP - Bullet.bullet1Damage;
    if(enemy1HP <= 0)
    {
    StartCoroutine(Die());
    }
IEnumerator Die()
{
    yield return  new WaitForSeconds(2);
    Destroy(gameObject);

}
}
private void OnTriggerEnter(Collider other) {
    if(other.tag == "checkpoint")
    {
        
        enemyMoveX = -enemyMoveX;
    }
}

}


