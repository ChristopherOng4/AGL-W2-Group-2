using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f; 
    public Rigidbody2D rb;
    public int damage = 20;
    public GameObject bulletEffect; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        rb.velocity = new Vector2(speed * transform.localScale.x, 0);
    }

    void OnTriggerEnter2D (Collider2D hitInfo) 
    {

        HealthSystem health = hitInfo.GetComponent<HealthSystem>(); 
        if (health != null)
        {   
           health.TakeDamage(damage);
        }

        Instantiate(bulletEffect, transform.position, transform.rotation);

        Destroy(gameObject);

    }
}
