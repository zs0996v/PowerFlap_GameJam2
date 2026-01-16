using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource backgroundMusic;
    public AudioSource powerUpSound;
    public AudioSource gameOverSound;

    void Awake()
    {
        instance = this;
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
