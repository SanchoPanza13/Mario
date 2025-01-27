using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    public GameObject player;    // Originalmente la var. se llamaba gameobject (sugerecia de c#), lo cual aparentemente buguea bastante

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())               // Si la deathzone detecta al jugador, invocamos al metodo resetplayer
        {
            player.GetComponent<PlayerMovement>().ResetPlayer();      //  Invocacion del resetplayer
        }
    }




}
