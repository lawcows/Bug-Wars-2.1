using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Vector3 enemyMoveX = new Vector3 (-1,0,0);
    public Vector3 enemyMoveZ = new Vector3 (0,0,-0.5f);


    public ParticleSystem explosionPS;
    public AudioSource screamSE;
    public Bullet bulletScript;


    public float enemySpeed;
    public float enemy1HP;
    public float bulletDamage;


    private void Update() {
        transform.Translate(enemyMoveX * enemySpeed * Time.deltaTime);
        transform.Translate(enemyMoveZ * enemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other) {
        GetHitted();
    }
    void GetHitted()
    {
        enemy1HP = enemy1HP - bulletScript.bullet1Damage;
        screamSE.GetComponent<AudioSource>().Play();
        ParticleSystem tExplosion = Instantiate(explosionPS, transform.position, Quaternion.identity);
        StartCoroutine(DestroyPS());
        if(enemy1HP <= 0)
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
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "checkpoint")
        {
        
            enemyMoveX = -enemyMoveX;
        }
    }

}

