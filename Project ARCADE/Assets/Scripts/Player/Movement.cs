using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float y = 1, x = 1;
    public float speed = 15;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            Destroy(other.gameObject);
        }
    }
    void Start()
    {
        
    }
    void Update()
    { 
        y = (Input.GetAxis("Vertical"));
        x = (Input.GetAxis("Horizontal"));

        if (y != 0 || x != 0)
        {
            transform.Translate(x * speed * Time.deltaTime, 0, y * speed * Time.deltaTime);
        }
    }
}
