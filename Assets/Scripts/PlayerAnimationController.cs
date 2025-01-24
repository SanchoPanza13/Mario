using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private Animator _animator;

    private PlayerMovement playerMovement;

    private SpriteRenderer SpriteRenderer;

    void Start()
    {
        _animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }




    void Update()
    {
        switch (playerMovement.GetPlayerState())
        {
            case PlayerState.IDLE:
                _animator.SetBool("isWalking", false);
                break;
            case PlayerState.WALKING:
                _animator.SetBool("isWalking", true);
                break;
            case PlayerState.JUMPING:
                break;
        }

        if (playerMovement.GetDirection().x < 0)
        {
            SpriteRenderer.flipX = true;
        }
        else if (playerMovement.GetDirection().x > 0)
        {
            SpriteRenderer.flipX = false;
        }

    }
}
