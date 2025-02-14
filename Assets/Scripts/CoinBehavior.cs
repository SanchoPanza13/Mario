using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{

    public GameObject jugador;

    float coin = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            GameManager.instance.AddCoins(coin);

            Destroy(gameObject);
        }
    }



}
