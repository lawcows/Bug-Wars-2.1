using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector3 direction;
    public float speed = 8;
    public float bullet1Damage = 30;

    Vector3 velocity;

    void Start()
    {
        Destroy(gameObject, 3);
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
