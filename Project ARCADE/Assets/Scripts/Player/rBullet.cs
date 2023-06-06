using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rBullet : MonoBehaviour
{

    public Transform playerTransform;
    public float radius, bulletSpeed;
    [Range(0,2)]public int bulletIndex =0;
    float parameter;
    rBullet [] redBullet;
    // Update is called once per frame

    private void Start() {
        redBullet = FindObjectsOfType<rBullet>();
        for( int i = 0 ; i < redBullet.Length; i++)
        {
            if(redBullet[i].bulletSpeed > bulletSpeed)
            {
                bulletSpeed = redBullet[i].bulletSpeed;
            }
        }
    }
    void Update()
    {
        Vector3 center = playerTransform.transform.position;
        parameter += Time.deltaTime * bulletSpeed;   
        float x = center.x + radius * Mathf.Cos(parameter + 2*bulletIndex);
        float z = center.z + radius * Mathf.Sin(parameter + 2*bulletIndex);
        transform.position = new Vector3 (x, 0, z);
    }
}
