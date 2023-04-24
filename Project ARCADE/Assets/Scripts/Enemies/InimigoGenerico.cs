using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoGenerico : MonoBehaviour
{
    //Variáveis desse Script
    float nextTimeToShoot;
    bool fireCooldown = true;
    public EnemySO enemySO;
    public Transform eBulletSpawner;
    public Shoot shoot;
    //Dentro do EnemySO
    GameObject enemyBullet;
    Transform playerTransform;
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
    bool followPlayer;

private void Start() {  
    //ScriptleObjects references 
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
    playerTransform = enemySO.playerTransform;
    followPlayer = enemySO.followPlayer;

    //Find player 
    playerTransform = GameObject.Find("Player").GetComponent<Transform>();
}

    private void Update() {
        Movement();
        if(!canShoot)  return;
        if (fireCooldown)
            StartCoroutine(GunShoot());
}

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")) return;
        GetHitted();
    }
    void GetHitted()
    {
        explosionAudio = GetComponent<AudioSource>();
        explosionAudio.Play();
        enemy1HP = enemy1HP - shoot.bulletDamage;
        ParticleSystem tExplosion = Instantiate(explosionPS, transform.position, Quaternion.identity);
        Destroy(tExplosion,1);
        if(enemy1HP <= 0)
        {
        Destroy(gameObject);
        }

    }
    void Movement()
    {
        if(followPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, enemySpeed * Time.deltaTime);
        }
        else if (!followPlayer)
        {
            transform.Translate(enemyMoveX * enemySpeed * Time.deltaTime);
            transform.Translate(enemyMoveZ * enemySpeed * Time.deltaTime);
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
