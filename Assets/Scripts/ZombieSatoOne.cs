using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSatoOne : MonoBehaviour
{
    private bool Salto = false;

    // public properties
    private float jumpForce = 15;

    // private components
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Salto)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // salta
            Salto = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Suelo")
            Salto = true;
    }
}
