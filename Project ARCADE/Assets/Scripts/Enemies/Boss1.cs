using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public GameObject [] targets;
    public GameObject bulletPrefab;
    public GameObject [] bulletSpawners;
    public AudioSource damageSE;
    public ParticleSystem explosionPS;
    public Shoot shoot;
    Vector3 direction;
    public float speed;
    public float bossHP = 20;
    public float moveTime;
    public float firerate;
    bool movement = false;
    void Start()
    {
        StartCoroutine(Shoot());
        
    }
    void Update()
    {
        if(movement){
        transform.Translate(direction * speed * Time.deltaTime);
        }
        else transform.Translate(Vector3.zero);
    }

    IEnumerator UpMovement()
    {
        direction = (targets[0].transform.position - transform.position).normalized;    
        movement = false;
        yield return new WaitForSecondsRealtime(moveTime);
        StartCoroutine(StopMovement1());
    }

    IEnumerator StopMovement1()
    {
        movement = true;
        yield return new WaitForSecondsRealtime(5);
        StartCoroutine(DownMovement());

    }

    IEnumerator DownMovement()
    {
        direction = (targets[1].transform.position - transform.position).normalized;    
        movement = false;
        yield return new WaitForSecondsRealtime(moveTime);
        StartCoroutine(StopMovement2());
    }

    IEnumerator StopMovement2()
    {
        movement = true;
        yield return new WaitForSecondsRealtime(5);
        StartCoroutine(UpMovement());
    }


    IEnumerator Shoot()
    {
        Debug.Log("Shooting");
        for(int i = 0; i< bulletSpawners.Length; i++)
        {
        Debug.Log("Shooting " +i);
        Instantiate(bulletPrefab, bulletSpawners[i].transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(1/firerate);
        }
        StartCoroutine(Shoot());
    }

private void OnCollisionEnter(Collision other) {
        GetHitted();
    }
    void GetHitted()
    {
        bossHP = bossHP - shoot.bulletDamage;
        damageSE.GetComponent<AudioSource>().Play();
        ParticleSystem tExplosion = Instantiate(explosionPS, transform.position, Quaternion.identity);
        StartCoroutine(DestroyPS());
        if(bossHP <= 0)
        {
        StartCoroutine(Die());
        }
    IEnumerator Die()
    {
        yield return  new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
        IEnumerator DestroyPS()
        {
            yield return new WaitForSecondsRealtime(1);
            Destroy(tExplosion);
        }
}
}