using UnityEngine;

public class Menu2_Amb : MonoBehaviour
{
    private float timeToRandomAmb = -1f;
    public AudioClip alien_squit;

    void Update()
    {
        if (timeToRandomAmb < 0f)
        {
            timeToRandomAmb = Random.Range(alien_squit.length, 30);
            GetComponent<AudioSource>().PlayOneShot(alien_squit);
        }

        if (timeToRandomAmb > 0f)
        {
            timeToRandomAmb -= Time.deltaTime;
        }
    }
}
