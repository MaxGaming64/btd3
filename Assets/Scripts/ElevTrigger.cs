using System.Collections;
using UnityEngine;

public class ElevTrigger : MonoBehaviour
{
    private bool used;
    public string animName;
    public GameObject trigger;
    public GameObject barrier;
    public AudioClip ambient;
    public Material xenSky;
    public GameObject skyCam;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") & !used)
        {
            used = true;
            barrier.SetActive(true);
            GetComponent<Animator>().Play(animName);
            RenderSettings.skybox = xenSky;
            skyCam.SetActive(false);
            StartCoroutine(Audio());
        }
    }

    IEnumerator Audio()
    {
        AudioSource audioSource = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();

        audioSource.clip = ambient;
        audioSource.volume = 1f;
        audioSource.Play();
        yield return new WaitForSeconds(6f);
        trigger.SetActive(true);
    }
}
