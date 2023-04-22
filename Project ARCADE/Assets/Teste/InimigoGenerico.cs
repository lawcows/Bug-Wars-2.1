using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoGenerico : MonoBehaviour
{
    float nextTimeToShoot;
    bool fireCooldown = true;
    public EnemySO enemySO;
    //Dentro do EnemySO
    GameObject enemyBullet;
    public Transform eBulletSpawner;
    ParticleSystem explosionPS;
    AudioSource explosionAudio;
    Bullet bulletScript;
    Vector3 enemyMoveX;
    Vector3 enemyMoveZ;
    float fireRate;
    float enemy1HP;
    float bulletDamage;
    float enemySpeed;
    bool canShoot;

private void Start() {  
    enemyMoveX = enemySO.moveX;
    enemyMoveZ = enemySO.moveZ;
    enemy1HP = enemySO.health;
    bulletDamage = enemySO.damage;
    enemySpeed = enemySO.speed;
    explosionPS = enemySO.explosionPS;
    explosionAudio = enemySO.explosionAudio;
    bulletScript = enemySO.bulletScript;
    fireRate = enemySO.fireRate;
    enemyBullet = enemySO.enemyBullet;
    canShoot = enemySO.canShoot;
}

    private void Update() {
        transform.Translate(enemyMoveX * enemySpeed * Time.deltaTime);
        transform.Translate(enemyMoveZ * enemySpeed * Time.deltaTime);
        if(!canShoot)  return;
        if (fireCooldown)
            StartCoroutine(GunShoot());
}

    private void OnCollisionEnter(Collision other) {
        GetHitted();
    }
    void GetHitted()
    {
        enemy1HP = enemy1HP - bulletScript.bullet1Damage;
        explosionAudio.GetComponent<AudioSource>().Play();
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
    IEnumerator GunShoot()
    {
        fireCooldown = false;
        GameObject temporaryBall;
        temporaryBall = Instantiate(enemyBullet, eBulletSpawner.transform.position, enemyBullet.transform.rotation) as GameObject;
        Rigidbody temporaryBallRB;
        temporaryBallRB = temporaryBall.GetComponent<Rigidbody>();
        temporaryBallRB.AddForce(eBulletSpawner.transform.forward);
        Destroy(temporaryBall, 50);
        nextTimeToShoot = Time.time;
        StartCoroutine(FireRateHandler());       
        yield return null;

       
        IEnumerator FireRateHandler()
        {
            float nextTimeToShoot = 1 / fireRate;
            yield return new WaitForSecondsRealtime(nextTimeToShoot);
            fireCooldown = true;
        }

    }
}
