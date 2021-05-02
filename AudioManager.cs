using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip playerDeath, eatBean, impact, boost; //all the audio variables
    static AudioSource audioSource; //the source from which the sound plays


    void Start()
    {
        playerDeath = Resources.Load<AudioClip>("OhBeans"); //we locate all the sounds and assign them to variables
        eatBean = Resources.Load<AudioClip>("EatBean");
        impact = Resources.Load<AudioClip>("Impact");
        boost = Resources.Load<AudioClip>("Boost");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip) //based on the input string, we play a desired sound
    {
        switch (clip)
        {
            case "OhBeans":
                audioSource.PlayOneShot(impact);
                audioSource.PlayOneShot(playerDeath);
                break;
            case "EatBean":
                audioSource.PlayOneShot(eatBean);
                break;
            case "Boost":
                audioSource.PlayOneShot(boost);
                break;
        }
    }
}
