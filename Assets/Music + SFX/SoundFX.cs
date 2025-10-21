using UnityEngine;

public class SoundFX : MonoBehaviour
{
    //death sfx initialization
    [SerializeField] AudioSource deathSFXSource;
    public AudioClip deathSFX;

    //hearbeat sfx initialization
    [SerializeField] AudioSource heartbeatSFXSource;
    public AudioClip heartbeatSFX;

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
}

