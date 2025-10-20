using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusicSource;

    public AudioClip bgMusic;

    private void Start()
    {
        backgroundMusicSource.clip = bgMusic;
        backgroundMusicSource.Play();
    }

}
