using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public float currentHealth; 
    public float maxHealth = 100;
     
    public GameObject deathEffect; 

    void Start() 
    {
        currentHealth = maxHealth; 
    }

    public void TakeDamage (float damage) 
    {
        currentHealth -= damage; 

        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("You're Dead");
            OnPlayerDeath?.Invoke();
        }
        
    }

    /*
    void Die () 
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    */
}
