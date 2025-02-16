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

    public float rayCastD = 1.5f;     // Distancia del raycast.

    public AudioClip enemySound1;

    public AudioClip enemySound2;

    public float volumeFX = 1f;

    private int soundRandomizer;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        soundRandomizer = Random.Range(0, 2);
    }

    void Update()
    {
        enemyPosX = (playerPos.transform.position.x);                             //Con esto pillamos las coord. X del jugador.

        posX = new Vector2(enemyPosX, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, posX, enemySpeed*Time.deltaTime);       //Con esto el enemigo se movera a donde este el jugador (eje de coordenadas x)(movetowards clasico)

        if (OnSide())
        {
            RandomSound(soundRandomizer);
            
            Destroy(gameObject);
        }

        if (OnTop())
        {
            playerPos.GetComponent<PlayerMovement>().ResetPlayer();      //Accedemos al componente playermovement de playerpos (el jugador)
        }
    }

    //Raycast = lanza un rayo para deterctar si hay algo

    bool OnSide()
    {
        bool outcome = Physics2D.Raycast(transform.position, Vector2.left, rayCastD, playerMask) || Physics2D.Raycast(transform.position, Vector2.right, rayCastD, playerMask);   //Solo detecta al tag PlayerMask (el jugador) cuando este toca por encima al enemigo

        return outcome;     
    }

    bool OnTop()
    {
        bool outcome = Physics2D.Raycast(transform.position, Vector2.up, rayCastD, playerMask);     //Solo detecta al tag PlayerMask (el jugador) cuando este toca por el lado del enemigo

        return outcome;
    }

    private void RandomSound(int RandNum)
    {
        switch (RandNum)
        {
            case 0:
                AudioManager.instance.PlayAudio(enemySound1, "enemy1");
                break;
            case 1:
                AudioManager.instance.PlayAudio(enemySound2, "enemy2", false ,volumeFX);
                break;
        }
    }





}
