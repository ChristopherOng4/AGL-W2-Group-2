using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100; 
     
    public GameObject deathEffect; 

    public void TakeDamage (int damage) 
    {
        currentHealth -= damage; 

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die () 
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
