using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class FinaleHelicopterTrigger : MonoBehaviour
{
    private Animator anim;
    private AudioSource mainMus;
    public GameObject player;
    public GameObject cutsceneCam;
    public GameObject joe;
    public GameObject fakeJoe;
    public GameObject baldi;
    public Animator fade;

    void Start()
    {
        anim = GetComponent<Animator>();
        mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (!mainMus.isPlaying)
        {
            SceneManager.LoadScene("Outro");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("Outro");
            player.SetActive(false);
            cutsceneCam.SetActive(true);
            joe.SetActive(false);
            fakeJoe.SetActive(true);
            baldi.SetActive(false);
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(5f);
        fade.Play("In");
        yield return new WaitForSeconds(5f);
        mainMus.loop = false;
    }
}
