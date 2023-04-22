using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "enemySO", menuName = "Enemy/newEnemy")]
public class EnemySO : ScriptableObject
{
    public Vector3 moveX;
    public Vector3 moveZ;
    public float health;
    public float damage;
    public float speed;
    public float fireRate;
    public bool canShoot;
    public bool followPlayer;
    public AudioSource explosionAudio;
    public ParticleSystem explosionPS;
    public Bullet bulletScript;
    public GameObject enemyBullet;
    public Transform playerTransform;
}
