using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InterfaceVariable { COINS, TIME } ;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private float coins = 0;
    private float timeCurrent = 0;
    private float testTime = 0f;

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
        testTime += Time.deltaTime;
    }




    public float GetCoins()
    {
        return coins;
    }

    public void AddCoins(float addCoin)
    {
        coins += addCoin;
    }

    public float GetTime()
    {
        return testTime;
    }








}
