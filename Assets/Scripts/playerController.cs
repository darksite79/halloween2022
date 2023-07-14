using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    public bool grounded;
    public float jumpPower = 6.5f;
    public float maxSpeed = 5f;
    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;
    private int puntos;
    private int life;


    /* Mejora del salto */
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    public bool betterJump = false;

    Vector3 initialPosition;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        initialPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Ground", grounded);
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && grounded == true)
        {
            jump = true;
        }
        
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); //INPUT WASD
        rb2d.AddForce(Vector2.right * speed * h);

        //Regular la velocidad del personaje

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }



        if (jump == true)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (betterJump)
        {
            if (rb2d.velocity.y < 0)
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
            }
           
            if (rb2d.velocity.y > 0 && !Input.GetKey("up"))
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
            }


        }

    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    public void resetPosition()
    {
        transform.position = initialPosition;
    }



    



}
