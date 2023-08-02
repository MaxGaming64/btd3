using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool moving = true;
    private bool goBack;
    public float speed = 5f;
    public float stopDelay = 2f;
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
            if (goBack)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            }

            else
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, endPosition) <= 0f && !goBack || Vector3.Distance(transform.position, startPosition) <= 0f && goBack)
            {
                StartCoroutine(ReachEnd());
            }
        }
    }

    IEnumerator ReachEnd()
    {
        moving = false;
        audioSource.Stop();
        audioSource.PlayOneShot(stopSound);
        yield return new WaitForSeconds(stopDelay);
        moving = true;
        goBack = !goBack;
        audioSource.Play();
    }
}
