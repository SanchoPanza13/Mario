using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    private Rigidbody2D rb2D;                          //Variable rigidbody

    //private Vector2 enemyDir;                          //Vector 

    public float enemySpeed = 5;                       //Velocidad del enemigo

    public GameObject enemy, playerPos;                //GameObjects de enemigo y jugador

    public LayerMask playerMask;                       //Layer del jugador

    private Vector2 posX;                              //Vector que actuara como vector objetivo en el movetowards

    private float enemyPosX;                           //Variable que guardara la posicion X del jugador para insertarla en el vector objetivo

    public float rayCastD = 1.5f;     // Distancia del raycast.

    public AudioClip enemySound1;     //Sonidos del enemigo

    public AudioClip enemySound2;

    public float volumeFX = 1f;       //Volumen

    private int soundRandomizer;      //Randomizador (aleatorizar el sonido que sale al matar al enemigo)

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();         //Acceder al componente rigidbody (acceder a las fisicas)

        soundRandomizer = Random.Range(0, 2);       //El randomizador tiene valores enteros entre el 0 y 1 (50%)
    }

    void Update()
    {
        enemyPosX = (playerPos.transform.position.x);                             //Con esto pillamos las coord. X del jugador.

        posX = new Vector2(enemyPosX, transform.position.y);                     //Creamos un vector con la posicion en el ejeX del jugador y la Y actual con el transform position

        transform.position = Vector2.MoveTowards(transform.position, posX, enemySpeed*Time.deltaTime);       //Con esto el enemigo se movera a donde este el jugador (eje de coordenadas x)(movetowards clasico)

        if (OnSide())        //Si el jugador toca por los lados mata al enemigo y suena el sonido
        {
            RandomSound(soundRandomizer);
            
            Destroy(gameObject);
        }

        if (OnTop())        //Si el jugador toca por encima resetea al jugador
        {
            playerPos.GetComponent<PlayerMovement>().ResetPlayer();      //Accedemos al componente playermovement de playerpos (el jugador), en especifico para resetear al jugador
        }
    }

    //Raycast = lanza un rayo para deterctar si hay algo

    bool OnSide()    //Metodo para detectar si el jugador se encuentra a los lados del enemigo
    {
        //raycast
        bool outcome = Physics2D.Raycast(transform.position, Vector2.left, rayCastD, playerMask) || Physics2D.Raycast(transform.position, Vector2.right, rayCastD, playerMask);   //Solo detecta al tag PlayerMask (el jugador) cuando este toca por encima al enemigo

        return outcome;     //Devuelve el resultado en forma de booleano
    }

    bool OnTop()    //Metodo para detectar si el jugador se encuentra encima del enemigo
    {
        bool outcome = Physics2D.Raycast(transform.position, Vector2.up, rayCastD, playerMask);     //Solo detecta al tag PlayerMask (el jugador) cuando este toca por el lado del enemigo

        return outcome;    //Devuelve el resultado en forma de booleano
    }

    private void RandomSound(int RandNum)      //Metodo para randomizar el sonido de los enemigos al morir
    {
        switch (RandNum)
        {
            case 0:
                AudioManager.instance.PlayAudio(enemySound1, "enemy1");       //Instanciamos del audiomanager
                break;
            case 1:
                AudioManager.instance.PlayAudio(enemySound2, "enemy2", false ,volumeFX);
                break;
        }
    }





}
