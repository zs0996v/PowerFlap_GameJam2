using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource backgroundMusic;
    public AudioSource powerUpSound;
    public AudioSource gameOverSound;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayPowerUpSound()
    {
        powerUpSound.Play();
    }

    public void PlayGameOverSound()
    {
        gameOverSound.Play();
        backgroundMusic.Stop();
    }

    public void StopBackgroundMusic()
    {
        backgroundMusic.Stop();
    }
}
