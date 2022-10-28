using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float moveSpeed; 
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shoot;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround; 

    public bool isGrounded;

    private Animator anim;

    public GameObject bullet;
    public Transform firePoint;

    private void OnEnable() 
    {
        HealthSystem.OnPlayerDeath += DisablePlayerMovement; 
    }

    private void OnDisable() 
    {
        HealthSystem.OnPlayerDeath -= DisablePlayerMovement; 
    }

    [SerializeField] private AudioSource jumpSoundEffect;

    [SerializeField] private AudioSource fireSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        EnablePlayerMovement();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround); 

        if(Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }
        else if (Input.GetKey(right)) 
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
        else 
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if(Input.GetKeyDown(jump) && isGrounded) 
        {
            jumpSoundEffect.Play();
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if(Input.GetKeyDown(shoot)) 
        {
            fireSoundEffect.Play();
            GameObject bulletClone = (GameObject)Instantiate(bullet, firePoint.position, firePoint.rotation);
            bulletClone.transform.localScale = transform.localScale / 3;
            anim.SetTrigger("Shoot");
        }

        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (theRB.velocity.x > 0) 
        {
            transform.localScale = new Vector3(1, 1, 1);
        } 

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);

    }

    private void DisablePlayerMovement() 
    {
        anim.enabled = false; 
        theRB.bodyType = RigidbodyType2D.Static; 
    }

    private void EnablePlayerMovement() 
    {
        anim.enabled = false; 
        theRB.bodyType = RigidbodyType2D.Dynamic; 
    }
}
