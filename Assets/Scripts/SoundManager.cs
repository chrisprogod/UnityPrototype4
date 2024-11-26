using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;  
    public AudioClip newWaveSound;   
    public AudioClip powerupCollectSound; 
    public AudioClip gameOverSound;

   
    public void PlayNewWaveSound()
    {
        audioSource.clip = newWaveSound;
        audioSource.Play();
    }

    
    public void PlayPowerupCollectSound()
    {
        audioSource.clip = powerupCollectSound;
        audioSource.Play();
    }

    public void GameOverSound()
    {
        audioSource.clip = gameOverSound;
        audioSource.Play();
    }
}