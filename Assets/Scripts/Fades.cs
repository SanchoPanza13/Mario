using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fades : MonoBehaviour
{
    private SpriteRenderer _rend;
    public float coroutineTime = 0.005f, fadeSpeed = 4;
    

    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
    }

    void Update()
    { 
        
    }

    IEnumerator FadeOut()    //Corrutina
    {
        for (float alpha = 1; alpha > 0; alpha -= Time.deltaTime * fadeSpeed)
        {
            Color newColor = _rend.color;
            newColor.a = alpha;
            _rend.color = newColor;

            yield return new WaitForSeconds(coroutineTime);
        }
        StartCoroutine(FadeIn());       //Recursion

    }

    IEnumerator FadeIn()
    {
        for (float alpha = 0; alpha <1; alpha += Time.deltaTime * fadeSpeed)
        {
            Color newColor = _rend.color;
            newColor.a = alpha;
            _rend.color = newColor;

            yield return new WaitForSeconds(coroutineTime);
        }
        StartCoroutine(FadeOut());
    }




    //Crear sonido, 1crear empty, 2ponemos nombre, 3metemos al componene audiosource, 4arrastrar audio a audioclip, 5customizar, 6(3D) Hijo del duenno de ese audio, 7Si no esta loopeado destruirlo.






}
