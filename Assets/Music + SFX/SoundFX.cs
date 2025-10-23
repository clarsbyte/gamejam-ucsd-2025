using System;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    //death sfx initialization
    [SerializeField] AudioSource deathSFXSource;
    public AudioClip deathSFX;

    //hearbeat sfx initialization
    [SerializeField] AudioSource heartbeatSFXSource;
    public AudioClip heartbeatSFX;

    //swing sfx initiliazation;
    [SerializeField] AudioSource swingSFXSource;
    public AudioClip[] swingsSFX;

    public void playDeathSFX()
    {
        deathSFXSource.clip = deathSFX;
        deathSFXSource.Play();
    }

    public void playHeartbeatSFX()
    {
        heartbeatSFXSource.clip = heartbeatSFX;
        heartbeatSFXSource.Play();
    }

    public void playSwingSFX()
    {
        // Test code
        // if ((int)Math.Round(UnityEngine.Random.Range(0.0F, 1.0F)) == 0)
        // {
        //     swingSFXSource.clip = swingsSFX[0];
        // }
        // else
        // {
        //     swingSFXSource.clip = swingsSFX[1];
        // }

        swingSFXSource.clip = swingsSFX[(int)Math.Round(UnityEngine.Random.Range(0.0F, 1.0F))];
        swingSFXSource.Play();
    }
}

