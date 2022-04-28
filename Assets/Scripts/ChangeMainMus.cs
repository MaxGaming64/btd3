using UnityEngine;

public class ChangeMainMus : MonoBehaviour
{
    public AudioClip clip;
    public float volume;
    public float pitch;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource audioSource = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();

            if (audioSource.clip != clip)
            {
                audioSource.clip = clip;
                audioSource.volume = volume;
                audioSource.pitch = pitch;
                audioSource.Play();
            }
        }
    }
}
