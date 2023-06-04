using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject [] bulletSpawners;
    public AudioSource damageSE;
    public ParticleSystem explosionPS;
    public Shoot shoot;
    Animator animator;
    public float bossHP = 20;
    public float firerate;
    private GameObject bossHealthBar;
    private GameObject[] bossHealthBarUnits;
    private float maxHealth; 
    bool shooting = false;

    public static bool boss1Defeated = false;
    void Start()
    {
        StartCoroutine(Iddle());
        maxHealth = bossHP;
        animator = GetComponent<Animator>();
        GameObject gameSession = GameObject.Find("GameSession");
        bossHealthBar = gameSession.GetComponent<GameSession>().bossHealthBar;
        bossHealthBarUnits = gameSession.GetComponent<GameSession>().bossHealthBarUnits;

        bossHealthBar.SetActive(true);
    }
    void Update()
    {

    }

    IEnumerator Iddle()
    {
       yield return new WaitForSecondsRealtime(4);
       animator.SetBool("Attack", true);
       StartCoroutine(BulletHell());
    }

    IEnumerator BulletHell()
    {
        yield return new WaitForSecondsRealtime(5);
        animator.SetBool("Attack", false);
        if(!shooting) 
        {
            StartCoroutine(Shoot());
        }
    }        
    IEnumerator Shoot()
    {
        shooting = true;
        yield return new WaitForSecondsRealtime(1/firerate);

            for(int i = 0; i< bulletSpawners.Length; i++)
            {
            Instantiate(bulletPrefab, bulletSpawners[i].transform.position, Quaternion.identity);
            }
            StartCoroutine(Shoot());       
    }

private void OnCollisionEnter(Collision other) {
        GetHitted();
    }
    void GetHitted()
    {
        bossHP = bossHP - shoot.bulletDamage;

        for (int i = 0; i < bossHealthBarUnits.Length; i++) {
            bool isActive = (bossHP/maxHealth) > (float)(bossHealthBarUnits.Length - i - 1)/(float)bossHealthBarUnits.Length;
            bossHealthBarUnits[i].SetActive(isActive);
        }
        damageSE.GetComponent<AudioSource>().Play();
        ParticleSystem tExplosion = Instantiate(explosionPS, transform.position, Quaternion.identity);
        Destroy(tExplosion, 1);
        if(bossHP <= 0)
        {
        StartCoroutine(Die());
        }
    IEnumerator Die()
    {
        boss1Defeated = true;
        yield return  new WaitForSeconds(0.5f);
        GameSession.level = 2;
        bossHealthBar.SetActive(false);
        Destroy(gameObject);
    }
}
}