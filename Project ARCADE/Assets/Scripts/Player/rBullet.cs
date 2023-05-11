using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rBullet : MonoBehaviour
{

    public Transform playerTransform;
    public float radius, bulletSpeed;
    float parameter;
    // Update is called once per frame
    void Update()
    {
        Vector3 center = playerTransform.transform.position;
        parameter += Time.deltaTime * bulletSpeed;   
        float x = center.x + radius * Mathf.Cos(parameter);
        float z = center.z + radius * Mathf.Sin(parameter);
        transform.position = new Vector3 (x, 0, z);
    }
}
