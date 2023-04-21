using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float enemySpeed = 0.2f;
    public GameObject bullet;
    public Transform bulletSpawner;
    private Transform playerTransform; 
    public Bullet bulletScript;
    Vector3 enemyMoveX = new Vector3 (1,0,0);
    Vector3 enemyMoveZ = new Vector3 (0,0,-0.5f);
    float nextShot;
    public float fireRate;
    public float enemy1HP = 100;
    public float bulletDamage= 30;

    private void Start() {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, enemySpeed * Time.deltaTime);

    }



    private void OnCollisionEnter(Collision other) {
        GetHitted();
    }
    void GetHitted()
    {
        enemy1HP = enemy1HP - bulletScript.bullet1Damage;
        if(enemy1HP <= 0)
        {
            StartCoroutine(Die());
        }
        IEnumerator Die()
        {
            yield return  new WaitForSeconds(1);
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


