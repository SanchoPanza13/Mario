using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    //Variables para completar el metodo PlayAudio
    public AudioClip musicSource;          //El clip de audio
    private bool isLoop = true;            //Si el audio hace loop
    public float volume = 1.0f;            //Volumen



    void Start()
    {
        AudioManager.instance.PlayAudio(musicSource, "Music", isLoop, volume);  //Accedemos al audiomanager e invocamos el metodo playaudio
    }
}
