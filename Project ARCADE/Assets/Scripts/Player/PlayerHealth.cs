using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public Image[] hearts;
    public GameObject player;
    int health;
    
    void Start() {
        health = hearts.Length;
    }

    private void OnCollisionEnter(Collision other) {
        health--;
        hearts[health].enabled = false;

        if(health == 0) {
            Destroy(player);
        }
    }
}
