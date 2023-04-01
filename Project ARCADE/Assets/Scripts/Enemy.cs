using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
public float enemySpeed = 0.2f;
Vector3 enemyMoveX = new Vector3 (1,0,0);
Vector3 enemyMoveZ = new Vector3 (0,0,-0.5f);
public float enemy1HP = 100;
public float bulletDamage= 30;
private void Update() {
    transform.Translate(enemyMoveX * enemySpeed * Time.deltaTime);
    transform.Translate(enemyMoveZ * enemySpeed * Time.deltaTime);
}

private void OnCollisionEnter(Collision other) {
    GetHitted();
}
void GetHitted()
{
    enemy1HP = enemy1HP - Bullet.bullet1Damage;
    if(enemy1HP <= 0)
    {
    StartCoroutine(Die());
    }
IEnumerator Die()
{
    yield return  new WaitForSeconds(2);
    Destroy(gameObject);

}
}
private void OnTriggerEnter(Collider other) {
    if(other.tag == "checkpoint")
    {
        
        enemyMoveX = -enemyMoveX;
    }
}

}

