using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float enemySpeed = 0.2f;
    private Transform playerTransform; 
    public Bullet bulletScript;
    public Shoot shoot;
    public float enemy1HP = 100;

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
        enemy1HP = enemy1HP - shoot.bulletDamage;
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
}


