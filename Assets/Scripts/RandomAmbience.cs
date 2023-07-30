using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomAmbience : MonoBehaviour
{
    private float timeToPlay;
    public float minWaitTime = 15f;
    public float maxWaitTime = 30f;
    public float minVolume = 1f;
    public float maxVolume = 1f;
    public float minPitch = 1f;
    public float maxPitch = 1f;
    private AudioSource audioSource;
    public AudioClip[] ambience;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timeToPlay = Random.Range(minWaitTime, maxWaitTime);
    }

    void Update()
    {
        timeToPlay -= Time.deltaTime;
        
        if (timeToPlay <= 0f)
        {
            timeToPlay = Random.Range(minWaitTime, maxWaitTime);
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.PlayOneShot(ambience[Random.Range(0, ambience.Length)], Random.Range(minVolume, maxVolume));
        }
    }
}
