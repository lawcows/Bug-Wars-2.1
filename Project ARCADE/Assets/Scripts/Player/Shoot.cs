using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot: MonoBehaviour
{
    [SerializeField] GameObject bullet, greenPlayer, redPlayer, fusionPlayer;
    [SerializeField] GameObject [] redBullet;
    [SerializeField] Transform bulletSpawner;
    float nextTimeToShoot;
    public float fireRate = 1;
    public float bulletDamage;
    public bool canfire = true;
    public int multishoot = 1;
    public AudioSource shootSound;
    public bool greenShoot, redShoot;

    public void Start() {
        //Checar qual o tipo de tiro disponível
        if(SelectPlayer.greenPlayerSelected)
        {
            greenShoot = true;
            redShoot = false;
        }
        else if(SelectPlayer.redPlayerSelected)
        {
            redShoot = true;
            greenShoot = false;
        }
        else if(SelectPlayer.fusionPlayerSelected)
        {
            redShoot = true;
            greenShoot = true;
        }

        // Ativar o tiro vermelho 
        if (redShoot)
        {
            redBullet[0].SetActive(true);
        }
        else
            redBullet[0].SetActive(false);

        // Selecionar personagem

        if(SelectPlayer.greenPlayerSelected)
        {
        greenPlayer.SetActive(true);
        redPlayer.SetActive(false);
        fusionPlayer.SetActive(false);
        }
        else if (SelectPlayer.redPlayerSelected)
        {
        greenPlayer.SetActive(false);
        redPlayer.SetActive(true);
        fusionPlayer.SetActive(false);
        }
        else if(SelectPlayer.fusionPlayerSelected)
        {
        greenPlayer.SetActive(false);
        redPlayer.SetActive(false);
        fusionPlayer.SetActive(true);
        }
    }

public void Update() 
{
        // Ativar o tiro verde
        if (canfire && greenShoot) 
            GunShoot();        
}


    void GunShoot()
    {   
        if(Input.GetKey(KeyCode.Mouse0))
        {  
            canfire = false;
            GameObject temporaryBall;
            temporaryBall = Instantiate(bullet, bulletSpawner.transform.position, bullet.transform.rotation) as GameObject;
            Rigidbody temporaryBallRB;
            temporaryBallRB = temporaryBall.GetComponent<Rigidbody>();
            temporaryBallRB.AddForce(bulletSpawner.transform.forward);   
            Destroy(temporaryBall, 5f);
            nextTimeToShoot = Time.time;

            // Checar se ultrapassou o limite de powerups de attackspeed
            if(fireRate >= 3)
            {
                fireRate = 3;
            }
            // limitador de multishoot
            if (multishoot >= 3)
            {
                multishoot = 3;
            }
            //Multishoot
            else if(multishoot>1 ){
                for(int i = 1; i <= multishoot && i< 6; i++)
                {
                StartCoroutine(AditionalShoot(i));
                }
            }
            StartCoroutine(FireRateHandler());
            shootSound.GetComponent<AudioSource>().Play();
        }
        IEnumerator FireRateHandler()
        {
            float nextTimeToShoot = (0.5f / fireRate) * multishoot;
            yield return new WaitForSecondsRealtime(nextTimeToShoot);
            canfire = true;
        }
        IEnumerator AditionalShoot(int i)
        {
            yield return new WaitForSecondsRealtime(0.1f*(i-1));
            GameObject temporaryBall;
            temporaryBall = Instantiate(bullet, bulletSpawner.transform.position, bullet.transform.rotation) as GameObject;
            Rigidbody temporaryBallRB;
            temporaryBallRB = temporaryBall.GetComponent<Rigidbody>();
            temporaryBallRB.AddForce(bulletSpawner.transform.forward);   
            Destroy(temporaryBall, 5f);
        }
    }
    public void SecondRedShoot()
    {
        redBullet[1].SetActive(true);
    }
    public void ThirdRedShoot()
    {
        redBullet[2].SetActive(true);
    }
}