using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    private GameObject player;   //Gameobject de jugador

    //Pese al nombre del script, este tambien se usa en la luz focal que sigue al jugador


    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;         //  Asignamos la variable player al jugador
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);     //  Que la camara se quede en el eje Y y Z dejado por el disennador (fijo). Siogue al jugador en el eje X.
    }
}
