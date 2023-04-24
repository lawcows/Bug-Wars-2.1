using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public Image[] hearts;
    public GameObject player;
    public float immuneTime;
    public float immuneBlinkTime;
    public Material playerMaterial;
    public AudioSource oof;
    public GameObject gameoverMenu;
    public ParticleSystem explosion;

    int health;
    bool isImmune = false;
    private Color playerColor;
    
    void Start() {
        health = hearts.Length;
        playerColor = playerMaterial.color;
    }

    void Update() {
        if (isImmune) {
            float v = Mathf.PingPong(Time.time, immuneBlinkTime);
            playerMaterial.color = Color.Lerp(playerColor, Color.red, v);
        } else {
            playerMaterial.color = playerColor;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (isImmune) return;

        isImmune = true;
        StartCoroutine(ImmuneTimer());

        health--;
        hearts[health].enabled = false;
        oof.Play();

        if(health == 0) {
            // aqui que vamos fazer o negocinho
        gameoverMenu.SetActive(true);
        ParticleSystem tExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(tExplosion,1);
        Destroy(player);
        }
    }

    IEnumerator ImmuneTimer() {
        yield return new WaitForSeconds(immuneTime);
        isImmune = false;
    }
}
