using System.Collections;
using UnityEngine;

public class MovingIsland : MonoBehaviour
{
    private bool moving = true;
    private bool goBack;
    private AudioSource audioSource;
    public AudioClip stopSound;
    private Vector3 startPosition;
    public Vector3 endPosition;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startPosition = transform.position;
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z + 1f);
    }

    void Update()
    {
        if (moving)
        {
            if (!goBack)
            {
                transform.position = Vector3.Lerp(transform.position, endPosition, Time.deltaTime * 0.5f);
            }

            else
            {
                transform.position = Vector3.Lerp(transform.position, startPosition, Time.deltaTime * 0.5f);
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
        yield return new WaitForSecondsRealtime(stopSound.length);
        moving = true;
        goBack = !goBack;
    }
}
