using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InterfaceVariable { COINS, TIME } ;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private float coins = 0;                                //Variable para monedas
    
    private float testTime = 0f;                            //Variable del tiempo

    private void Awake()
    {
        //Esto es un singleton
        if (!instance)
        {
            instance = this;                                 //
            DontDestroyOnLoad(gameObject);                   //Si la escena se cambia no se destuye el gamemanager

        }
        else
        {
            Destroy(gameObject);                             //En el caso contrario, lo destruye
        }
    }
       
    void Update()
    {
        testTime += Time.deltaTime;                          //Contador del tiempo
    }




    public float GetCoins()                                 //Metodo que devuelve la cantidad de moneda
    {
        return coins;
    }

    public void AddCoins(float addCoin)                     //Metodo de suma de moneda
    {
        coins += addCoin;
    }

    public float GetTime()                                 //Metodo que devuelve el tiempo actual
    {
        return testTime;
    }








}
