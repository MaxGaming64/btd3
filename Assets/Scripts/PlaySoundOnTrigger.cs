using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume;
    public bool playOneShot;
    public bool destroyOnTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!playOneShot)
            {
                audioSource.clip = clip;
                audioSource.Play();
            }

            else
            {
                audioSource.PlayOneShot(clip, volume);
            }
        }
    }
}
