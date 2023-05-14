using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public GameObject boss;
    Vector3 direction;
    Rigidbody rb;
    public float speed;
    private void Start() {
        direction = new Vector3(0, 0, -1);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * speed);
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }
}
