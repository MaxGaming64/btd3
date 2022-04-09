using System.Collections;
using UnityEngine;

public class ElevTrigger : MonoBehaviour
{
    private bool used;
    public string animName;
    public GameObject trigger;
    public AudioClip ambient;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") & !used)
        {
            used = true;
            GetComponent<Animator>().Play(animName);
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
