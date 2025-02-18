using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public enum PlayerState {IDLE, WALKING, JUMPING }



public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;

    private Vector2 directionVec;

    public float speed = 10, jumpForce = 11, heightToScan = 2f;

    public LayerMask grndMask;

    public AudioClip jumpingClip;

    private bool isJumping = false;

    private PlayerState _currentState;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        
    }

    
    void Update()
    {
        directionVec = new Vector2(Input.GetAxis("Horizontal"), 0);    // Movimiento horizontal jugador

        Jump();

        if (directionVec.magnitude == 0)                              // Si es 0 el jugador esta quieto (IDLE)
        {
            _currentState = PlayerState.IDLE;
        }
        else
        {
            _currentState = PlayerState.WALKING;
        }
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

            _currentState = PlayerState.JUMPING;

            AudioManager.instance.PlayAudio(jumpingClip, "jumpingSoundObjects");
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

    public PlayerState GetPlayerState()
    {
        return _currentState;
    }

    public Vector2 GetDirection()
    {
        return directionVec;
    }

}
