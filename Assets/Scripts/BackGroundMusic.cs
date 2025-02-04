using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{

    public AudioClip musicSource;
    private bool isLoop = true;
    public float volume = 1.0f;



    void Start()
    {
        AudioManager.instance.PlayAudio(musicSource, "Music", isLoop, volume);  //Cogemos del Script AudioManager
    }
}
