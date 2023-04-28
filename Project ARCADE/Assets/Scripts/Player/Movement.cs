using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float y = 1, x = 1;
    public float speed = 15;
    public BoxCollider movementBounds;
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


        // Get the current position of the player
        Vector3 currentPosition = transform.position;

        // Clamp the position to stay inside the movementBounds
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(currentPosition.x, movementBounds.bounds.min.x, movementBounds.bounds.max.x),
            Mathf.Clamp(currentPosition.y, movementBounds.bounds.min.y, movementBounds.bounds.max.y),
            Mathf.Clamp(currentPosition.z, movementBounds.bounds.min.z, movementBounds.bounds.max.z));

        // Update the position of the player
        transform.position = clampedPosition;
    }
}
