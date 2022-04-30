using UnityEngine;

public class PauseAudio : MonoBehaviour
{
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.timeScale == 0f)
        {
            audioSource.Pause();
        }

        else
        {
            if (!audioSource.isPlaying)
            {
                audioSource.UnPause();
            }
        }
    }
}
