using System.Collections;
using UnityEngine;

public class CreepyHighTrigger : MonoBehaviour
{
    private bool used;
    public GameObject player;
    public GameObject Camera;
    public AudioClip creepyHigh;
    public AudioClip ambient;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") & !used)
        {
            used = true;
            StartCoroutine(CreepyHigh());
        }
    }

    IEnumerator CreepyHigh()
    {
        AudioSource mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();
        
        player.SetActive(false);
        Camera.SetActive(true);
        mainMus.loop = false;
        mainMus.clip = creepyHigh;
        mainMus.Play();
        yield return new WaitForSeconds(creepyHigh.length);
        player.SetActive(true);
        Camera.SetActive(false);
        mainMus.loop = true;
        mainMus.clip = ambient;
        mainMus.Play();
    }
}
