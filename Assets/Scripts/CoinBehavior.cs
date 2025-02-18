using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{

    public GameObject player;        //Gameobject para el jugador
     
    float coin = 1;                  //Variable de monedas

    public AudioClip coinSound1;     //Variables audioclip

    public AudioClip coinSound2;

    public float volumeFX = 1f;      //volumen

    private int randomizer;          //Randomizador (aleatorizar el sonido que sale al coger una moneda)

    private void Start()
    {
        randomizer = Random.Range(0, 2);     //El randomizador tiene valores enteros entre el 0 y 1 (50%)
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())      //Si el gameobject tiene el componente playermovement (el jugador)
        {
            GameManager.instance.AddCoins(coin);                      //Invocamos al metodo addcoins para sumar la moneda al texto

            RandomCoinSound(randomizer);                              //Suena el audio

            Destroy(gameObject);                                      //Destruye la moneda
        }
    }

    private void RandomCoinSound(int randNum)       //Randomizar el sonido, igual que en el script EnemyBehaviour
    {
        switch (randNum)
        {
            case 0:
                AudioManager.instance.PlayAudio(coinSound1, "Coin1", false, volumeFX);
                break;
            case 1:
                AudioManager.instance.PlayAudio(coinSound2, "Coin2", false, volumeFX);
                break;

        }
    }

}
