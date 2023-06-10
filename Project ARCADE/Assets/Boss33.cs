using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss33 : MonoBehaviour
{
    public GameObject [] bulletPrefab;
    public Transform [] bulletSpawners;
    private GameObject bossHealthBar;
    private GameObject[] bossHealthBarUnits;
    public AudioSource damageSE;
    public ParticleSystem explosionPS;
    public Shoot shoot;
    Animator animator;
    private float maxHealth;
    public float bossHP = 100;
    [Range(0,1)] public float firerate;
    public static bool boss33Defeated = false;
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
            boss33Defeated = true;
            GameSession.level = 3;
            Destroy(gameObject, 0.5f);
        }
    }

    public void Attack()
    {
        Debug.Log("Attack !");
    StartCoroutine(AttackRepeating());      
    }

    IEnumerator AttackRepeating()
    {
        yield return new WaitForSecondsRealtime(firerate);
        for(int i = 0; i < bulletSpawners.Length; i++)
        {
        Instantiate(bulletPrefab[i], bulletSpawners[i].position, Quaternion.identity);
        }
        StartCoroutine(AttackRepeating());
    }

    public void StopAttack()
    {
        StopAllCoroutines();
    }
}
