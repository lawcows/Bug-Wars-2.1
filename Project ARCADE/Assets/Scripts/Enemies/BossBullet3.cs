using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet3 : MonoBehaviour
{
Rigidbody rb;
private void Start() {
    rb = GetComponent<Rigidbody>();
    rb.AddForce(new Vector3(0,0,-1) * 500);
Destroy(gameObject, 10f);
}
}
