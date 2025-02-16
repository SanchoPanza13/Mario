using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{

    public GameObject jugador;

    float coin = 1;

    public AudioClip coinSound1;

    public AudioClip coinSound2;

    public float volumeFX = 1f;

    private int randomizer;

    private void Start()
    {
        randomizer = Random.Range(0, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            GameManager.instance.AddCoins(coin);

            RandomCoinSound(randomizer);

            Destroy(gameObject);
        }
    }

    private void RandomCoinSound(int randNum)
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
