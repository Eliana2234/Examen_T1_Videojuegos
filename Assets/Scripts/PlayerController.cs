using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool Muere = false;

    // public properties
    private float velocityX = 6;
    private float jumpForce = 12;

    // private components
    private Rigidbody2D rb;
    private Animator animator;

    //Constants
    private const int ANIMATION_RUN = 0;
    private const int ANIMATION_JUMP = 1;
    private const int ANIMATION_DEAD = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Muere)
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y); //moverse automáticamente
            changeAnimation(ANIMATION_RUN);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.velocity = new Vector2(velocityX, 0);
                rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse); 
                changeAnimation(ANIMATION_JUMP); 
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0); +
            changeAnimation(ANIMATION_DEAD);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Enemy") // Muere
            Muere = true;
    }
    22
    private void changeAnimation(int animation) 
    {
        animator.SetInteger("Estado", animation); 
    }

}
