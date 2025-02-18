using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class TextBehaviour : MonoBehaviour
{

    public InterfaceVariable variableToUpdate;      //Variable de texto publica

    private TMP_Text textToUpdate;                  //Variable para actualizar el texto

    private void Start()
    {
        textToUpdate=GetComponent<TMP_Text>();
    }

    private void Update()
    {
        switch(variableToUpdate)
        {
            case InterfaceVariable.COINS:
                textToUpdate.text = "Monedas recogidas: " + GameManager.instance.GetCoins() + "/10";
                break;
            case InterfaceVariable.TIME:
                textToUpdate.text="Tiempo transcurrido: " + GameManager.instance.GetTime().ToString("00.00" + " s");
                break;
        }
    }
}
