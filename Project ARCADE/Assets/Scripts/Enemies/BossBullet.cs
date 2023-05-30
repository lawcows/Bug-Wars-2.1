using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public Transform boss;
    Vector3 direction;
    Rigidbody rb;
    public float speed;
    private void Start() {
        direction = (transform.position - boss.transform.position).normalized;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * speed);
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }
}
