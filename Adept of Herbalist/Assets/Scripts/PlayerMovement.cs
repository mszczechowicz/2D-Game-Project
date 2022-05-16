using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private float jumpforce;
    [SerializeField] private bool grounded;
    [SerializeField] private AudioSource step;
   

    private bool dbljump;

    public Transform groundcheck;
    public float checkradius;
    public LayerMask whatisground;




    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        step = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1 ,1);
       // else
         //   body.velocity = new Vector2(0, body.velocity.y); 


        


        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);


        //if (Input.GetButtonDown("Jump") && grounded)
        //  Jump();
        


        // JUMPING & DOUBLE JUMPING
        if (grounded)
        {
            dbljump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                Jump();
                anim.SetTrigger("jump");
            }
            else 
            {
                if (dbljump)
                {
                    Jump();
                    anim.SetTrigger("secondjump");
                    dbljump = false;                 
                }            
            }
        }


        //groundchecking

        grounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatisground);


    }

    private void Jump()
    {
        // body.velocity = new Vector2(body.velocity.x, jumpforce);

        GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpforce;             
        grounded = false;     
    }





    //private void OnCollisionEnter2D(Collision2D collision)
    // {
    //    if (collision.gameObject.tag == "Ground")
    //        grounded = true;
    //}

    private void Footstep()
    {
        step.Play();
    }
   

}
