using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss31 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject boss2;
    private GameObject bossHealthBar;
    private GameObject[] bossHealthBarUnits;
    public Transform[] bulletSpawners;
    public AudioSource damageSE;
    public ParticleSystem explosionPS;
    public Shoot shoot;
    private float maxHealth;
    Animator animator;
    public float bossHP = 100;
    bool boss31Defeated = false;
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
        // mover interface de vida do boss na UI
        for (int i = 0; i < bossHealthBarUnits.Length; i++) 
        {
            bool isActive = (bossHP/maxHealth) > (float)(bossHealthBarUnits.Length - i - 1)/(float)bossHealthBarUnits.Length;
            bossHealthBarUnits[i].SetActive(isActive);
        }
        Destroy(tExplosion, 1);
        if (bossHP <= 0)
        {
            //Boss Derrotado
            if(!boss31Defeated)
            {
            Instantiate(boss2, boss2.transform.position, boss2.transform.rotation);
            }
            boss31Defeated = true;
            Destroy(gameObject, 0.5f);
        }
    }

    public void Attack()
    {
        for(int i = 0 ; i < bulletSpawners.Length; i++)
        {
        Instantiate(bulletPrefab, bulletSpawners[i].position, Quaternion.identity);
        }
    }
}
