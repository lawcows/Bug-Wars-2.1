using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartLifeSystem : MonoBehaviour
{
    public int maxHealth = 3; 
    public int currentHealth; 
    public Image[] heartImages; 

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage()
    {
        currentHealth--;
        UpdateHearts();
    }

    public void Heal()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            UpdateHearts();
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHealth)
            {
                heartImages[i].enabled = true;
            }
            else
            {
                heartImages[i].enabled = false;
            }
        }
    }
}
