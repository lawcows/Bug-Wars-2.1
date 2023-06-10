using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss32 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject boss3;
    public Transform bulletSpawners;
    private GameObject bossHealthBar;
    private GameObject[] bossHealthBarUnits;
    public AudioSource damageSE;
    public ParticleSystem explosionPS;
    public Shoot shoot;
    Animator animator;
    private float maxHealth;
    public float bossHP = 100;
    [Range(0,1)] public float firerate;
    bool boss32Defeated = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        GameObject gameSession = GameObject.Find("GameSession");
        bossHealthBar = gameSession.GetComponent<GameSession>().bossHealthBar;
        bossHealthBarUnits = gameSession.GetComponent<GameSession>().bossHealthBarUnits;
        bossHealthBar.SetActive(true);
    }
    void Update()
    {    }
    private void OnCollisionEnter(Collision other)
    {
        // recebeu dano
        GetHitted();
    }
    void GetHitted()
    {
        bossHP = bossHP - shoot.bulletDamage;
        damageSE.GetComponent<AudioSource>().Play();
        ParticleSystem tExplosion = Instantiate(explosionPS, transform.position, Quaternion.identity);
        Destroy(tExplosion, 1);
        for (int i = 0; i < bossHealthBarUnits.Length; i++) 
        {
            bool isActive = (bossHP/maxHealth) > (float)(bossHealthBarUnits.Length - i - 1)/(float)bossHealthBarUnits.Length;
            bossHealthBarUnits[i].SetActive(isActive);
        }
        if (bossHP <= 0)
        {
            // Boss derrotado
            if(!boss32Defeated)
            {
            Instantiate(boss3, boss3.transform.position, boss3.transform.rotation);
            }
            boss32Defeated = true;
            GameSession.level = 3;
            Destroy(gameObject, 0.5f);
        }
    }

    public void Attack()
    {
    StartCoroutine(AttackRepeating());      
    }

    IEnumerator AttackRepeating()
    {
        yield return new WaitForSecondsRealtime(firerate);
        Instantiate(bulletPrefab, bulletSpawners.position, Quaternion.identity);
        StartCoroutine(AttackRepeating());
    }

    public void StopAttack()
    {
        StopAllCoroutines();
    }
}
