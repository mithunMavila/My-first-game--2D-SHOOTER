using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private float DirX;
    [SerializeField] private float JumpForce = 14f;
    [SerializeField] private float MoveSpeed = 7f;
    [SerializeField] private LayerMask JumpableGround;
  //  [SerializeField] private AudioSource jumpSound;
    public Animator anim;
   // public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();   
        coll=GetComponent<BoxCollider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
         DirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(DirX*MoveSpeed,rb.velocity.y);
        if (DirX > 0)
        {
            transform.localScale=new Vector3(1f,1f,1f);
        }
        if (DirX < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
       if(DirX !=0 )
        {
            anim.SetBool("Walk", true);
           
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x,JumpForce);
           // jumpSound.Play();
          
        }
        if(!IsGrounded())
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
   
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "break")
        {
            Destroy(collision.gameObject,2f);
        }
    }
}
