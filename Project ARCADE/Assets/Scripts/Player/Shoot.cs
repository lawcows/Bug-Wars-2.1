using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot: MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawner;
    float nextTimeToShoot;
    public float fireRate = 1;
    public float bulletDamage;
    public bool canfire = true;
    public int multishoot = 1;
    public int critRate;
    public AudioSource shootSound;

    public void Start() {
    }

public void Update() 
{
    if(canfire)
    StartCoroutine(GunShoot());
}


    IEnumerator GunShoot()
{
    //Calcular se vai ser critico ou não
    int r = Random.Range(1,5);
    if(r<=critRate)
    {
        // critico
    }
    else // normal


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

            //Multishoot
            if(multishoot>1){
                for(int i = 1; i <= multishoot && i< 6; i++)
                {
                StartCoroutine(AditionalShoot(i));
                }
            }
            StartCoroutine(FireRateHandler());
            shootSound.GetComponent<AudioSource>().Play();
            yield return null;
    }
    IEnumerator FireRateHandler()
    {
        float nextTimeToShoot = 1 / fireRate;
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
}