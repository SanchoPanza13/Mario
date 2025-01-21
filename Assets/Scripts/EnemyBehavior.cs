using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    private Rigidbody2D rb2D;

    private Vector2 enemyDir;

    public float enemySpeed = 5;

    public GameObject enemy, playerPos;

    public LayerMask playerMask;

    private Vector2 posX;

    private float enemyPosX;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        enemyPosX = (playerPos.transform.position.x);                             //Con esto pillamos las coord. X del jugador.

        posX = new Vector2(enemyPosX, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, posX, enemySpeed*Time.deltaTime);       //Con esto el enemigo se movera a donde este el jugador (eje de coordenadas x)(movetowards clasico)

        if (OnSide())
        {
            playerPos.GetComponent<PlayerMovement>().ResetPlayer();      //Accedemos al componente playermovement de playerpos (el jugador)
        }

        if (OnTop())
        {
            Destroy(gameObject);
        }
    }

    //Raycast = lanza un rayo para deterctar si hay algo

    bool OnSide()
    {
        bool outcome = Physics2D.Raycast(transform.position, Vector2.left, 1f, playerMask) || Physics2D.Raycast(transform.position, Vector2.right, 1f, playerMask);   //Solo detecta al tag PlayerMask (el jugador)

        return outcome;
    }

    bool OnTop()
    {
        bool outcome = Physics2D.Raycast(transform.position, Vector2.up, 1.3f, playerMask);

        return outcome;
    }







}
