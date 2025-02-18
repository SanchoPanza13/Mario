using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private Animator _animator;                                //Variable animator

    private PlayerMovement playerMovement;                     //Variable playermovement

    private SpriteRenderer SpriteRenderer;

    void Start()
    {
        _animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }




    void Update()
    {
        switch (playerMovement.GetPlayerState())    // Metodo que detecta cuando el jugador se mueve o no, para asignar la animacion correcta.
        {
            case PlayerState.IDLE:
                _animator.SetBool("isWalking", false);         // Cuando el bool isWalking sea falso se pone la animacion idle
                break;
            case PlayerState.WALKING:
                _animator.SetBool("isWalking", true);
                break;
            case PlayerState.JUMPING:
                break;
        }

        if (playerMovement.GetDirection().x < 0)       // Metodo para darle la vuelta al sprite cuando este vaya a la izq.
        {
            SpriteRenderer.flipX = true;
        }
        else if (playerMovement.GetDirection().x > 0)
        {
            SpriteRenderer.flipX = false;
        }

    }




}
