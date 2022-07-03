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
    public Vector3 startDirection;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startPosition = transform.position;
        transform.position = transform.position + startDirection;
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

            if (Vector3.Distance(transform.position, endPosition) <= 1f | Vector3.Distance(transform.position, startPosition) <= 1f)
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
