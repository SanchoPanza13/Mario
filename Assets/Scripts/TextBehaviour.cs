using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class TextBehaviour : MonoBehaviour
{

    public InterfaceVariable variableToUpdate;

    private TMP_Text textToUpdate;

    private void Start()
    {
        textToUpdate=GetComponent<TMP_Text>();
    }

    private void Update()
    {
        switch(variableToUpdate)
        {
            case InterfaceVariable.COINS:
                textToUpdate.text = "Monedas disponibles: " + GameManager.instance.GetCoins();
                break;
            case InterfaceVariable.TIME:
                textToUpdate.text="Tiempo transcurrido: " + GameManager.instance.GetTime().ToString("00.00" + " s");
                break;
        }
    }
}
