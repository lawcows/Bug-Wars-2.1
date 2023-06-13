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
    private GameObject bossHealthBar;
    private GameObject[] bossHealthBarUnits;
    private float maxHealth; 

    public static bool boss1Defeated = false;
    void Start()
    {
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
    public void Shoot()
    {
            for(int i = 0; i< bulletSpawners.Length; i++)
            {
            Instantiate(bulletPrefab, bulletSpawners[i].transform.position, Quaternion.identity);
            }      
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
        boss1Defeated = true;
        GameSession.level = 2;
        bossHealthBar.SetActive(false);
        Destroy(gameObject, 0.5f);
        }

}
}