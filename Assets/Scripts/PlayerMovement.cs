using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;

    private Vector2 directionVec;

    public float speed = 10, jumpForce = 10, heightToScan = 2f;

    public LayerMask grndMask;

    private bool isJumping = false;





    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        directionVec = new Vector2(Input.GetAxis("Horizontal"), 0);    // Movimiento horizontal jugador

        Jump();
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(directionVec.x*speed, rb2D.velocity.y);        // Velocidad max. de caida
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && OnGround())
        {
            isJumping = true;

            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);            // Siempre salta con la misma fuerza, sin verse afectado por la gravedad

            rb2D.AddForce(Vector2.up * jumpForce * rb2D.gravityScale, ForceMode2D.Impulse);     // Aseguramos que siempre supere la gravedad al multiplicar rb2D.gravityScale
        }
    }

    private bool OnGround()      
    {
       bool contact = Physics2D.Raycast(transform.position, Vector2.down, heightToScan, grndMask);         // Castearemos un circulo en los pies del jugador
        
        isJumping = false;

        return contact;   //(no es nada=null) solo devuelve cuando no esta en contacto con el suelo, con tal de no hacer el doble salto
    }

    public void ResetPlayer()
    {
        gameObject.transform.position = new Vector2(-8.0182f, -1.794f);
    }


}
