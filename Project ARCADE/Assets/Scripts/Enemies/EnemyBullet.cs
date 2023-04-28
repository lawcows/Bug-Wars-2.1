using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public Vector3 direction = new Vector3 (-1, 0, 0);
    public float speed = 8;
    static public float bullet1Damage = 30;

    public Vector3 velocity;

    void Start()
    {
        Destroy(gameObject, 6);
    }
    void Update()
    {
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;

        pos += velocity * Time.deltaTime;

        transform.position = pos;
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }
}
