using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float y = 1, x = 1;
    public float speed = 5;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        y = (Input.GetAxis("Vertical"));
        x = (Input.GetAxis("Horizontal"));

        if (y != 0 || x != 0)
        {
            transform.Translate(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0);
        }

 
    }
}
