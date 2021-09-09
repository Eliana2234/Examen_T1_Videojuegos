using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSLR : MonoBehaviour
{
    private bool Salto = false;

    // public properties
    private float velocityX = 4;
    private float jumpForce = 7;

    // private components
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Salto)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse); 
            Salto = false; //down
            if (sr.flipX)
            {
                rb.velocity = new Vector2(velocityX, rb.velocity.y); // L
                sr.flipX = false;
            }
            else
            {
                rb.velocity = new Vector2(-velocityX, rb.velocity.y);  // R
                sr.flipX = true;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Suelo")
            Salto = true;
    }
}
