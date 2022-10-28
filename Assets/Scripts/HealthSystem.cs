using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float currentHealth; 
    public float maxHealth = 100;
     
    public GameObject deathEffect; 

    void Start() 
    {
        currentHealth = maxHealth; 
    }

    public void TakeDamage (int damage) 
    {
        currentHealth -= damage; 

        /*
        if (currentHealth <= 0)
        {
            Die();
        }
        */
    }

    /*
    void Die () 
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    */
}
