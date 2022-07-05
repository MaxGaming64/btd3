using UnityEngine;

public class ChangeMainMus : MonoBehaviour
{
    public AudioClip clip;
    public float volume;
    public float pitch;
    public bool seamless;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource audioSource = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();

            if (audioSource.clip != clip)
            {
                float num = audioSource.time;

                audioSource.clip = clip;
                audioSource.volume = volume;
                audioSource.pitch = pitch;
                audioSource.Play();

                if (seamless)
                {
                    audioSource.time = num;
                }

                else
                {
                    audioSource.time = 0f;
                }
            }
        }
    }
}
