using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUMove : MonoBehaviour
{
    public Vector3 moveDirection;
    public float speed = 10;

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
