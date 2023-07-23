using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool moving = true;
    private bool goBack;
    public float speed;
    private AudioSource audioSource;
    public AudioClip stopSound;
    private Vector3 startPosition;
    public Vector3 endPosition;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (moving)
        {
            if (!goBack)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            }

            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, endPosition) <= 0f & !goBack | Vector3.Distance(transform.position, startPosition) <= 0f & goBack)
            {
                StartCoroutine(ReachEnd());
            }

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    IEnumerator ReachEnd()
    {
        moving = false;
        audioSource.Stop();
        audioSource.PlayOneShot(stopSound);
        yield return new WaitForSeconds(stopSound.length);
        moving = true;
        goBack = !goBack;
    }
}
