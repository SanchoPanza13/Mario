using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    //Crear sonido, 1crear empty, 2ponemos nombre, 3metemos al componene audiosource, 4arrastrar audio a audioclip, 5customizar, 6(3D) Hijo del duenno de ese audio, 7Si no esta loopeado destruirlo.

    public static AudioManager instance;
    private List<AudioSource> sounds;  

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            sounds = new List<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    public AudioSource PlayAudio(AudioClip clip, string gameObjectName, bool isLoop = false, float volume = 1.0f )
    {
        // 1- Crear empty
        GameObject nObject = new GameObject();

        //2- Ponerle nombre
        nObject.name = gameObjectName;

        //3- Annadir el audiosource
        AudioSource audioSourceComponent = nObject.AddComponent<AudioSource>();

        //4- Arrastrar audioclip
        audioSourceComponent.clip = clip;

        //5- Seteamos el loop
        audioSourceComponent.loop = isLoop;

        //6- Regular propiedades
        audioSourceComponent.volume = volume;

        //7- Annadimos el objeto a la lista
        sounds.Add(audioSourceComponent);

        //8- que suene
        audioSourceComponent.Play();

        //9- Cuando deje de sonar se destruye (performance)
        StartCoroutine(WaitForAudio(audioSourceComponent));

        return audioSourceComponent;
    }

    private IEnumerator WaitForAudio(AudioSource source)
    {

        if (source.loop)
        {
            yield return null;
        }

        //Esperamos mientras el audio este sonando
        while (source.isPlaying)
        {
            yield return new WaitForSeconds(0.3f);
        }

        //Cuando el audio deja de sonar lo destruimos

        Destroy(source.gameObject);
    }

}
