using System.Collections;
using UnityEngine;

public class MovingIsland : MonoBehaviour
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
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z + 1f);
    }

    void FixedUpdate()
    {
        if (moving)
        {
            if (!goBack)
            {
                transform.Translate(transform.forward * speed * Time.deltaTime);
            }

            else
            {
                transform.Translate(-transform.forward * speed * Time.deltaTime);
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
