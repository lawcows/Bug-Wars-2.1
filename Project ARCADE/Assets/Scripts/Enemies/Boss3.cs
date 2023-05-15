using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss3 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject[] bulletSpawners;
    public AudioSource damageSE;
    public ParticleSystem explosionPS;
    public Shoot shoot;
    Animator animator;
    public float bossHP = 100;
    public float firerate;
    public static bool boss3Defeated = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        // Inicia sequencia para atacar
        StartCoroutine(Attack());
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
        if (bossHP <= 0)
        {
            // Boss derrotado
            boss3Defeated = true;
            GameSession.level = 2;
            Destroy(gameObject, 0.5f);
        }
    }
    IEnumerator ShootLR()
    {
        // Inicia contagem para realizar ataques
        yield return new WaitForSecondsRealtime(3.5f);
        for( int w = 0; w < 3; w++) // Loop para realizar 03 sequências de atack
        {
            yield return new WaitForSecondsRealtime(w * 1.5f);
            for (int i = 0; i < bulletSpawners.Length; i++) // Loop para spawnar os tiros na sequência correta
            {
                StartCoroutine(ShootUpTimer(i));
            }
        }
            StartCoroutine(Attack());
    }

    IEnumerator ShootUpTimer(int i)
    {
        // Timer entre cada tiro
        yield return new WaitForSecondsRealtime(i/2f);
        Instantiate(bulletPrefab, bulletSpawners[i].transform.position, Quaternion.identity);
    }

    IEnumerator Attack()
    {
        // Inicia contagem para animação de ataque
        yield return new WaitForSecondsRealtime(10);
        animator.SetTrigger("Attack");
        StartCoroutine(ShootLR());
    }
}