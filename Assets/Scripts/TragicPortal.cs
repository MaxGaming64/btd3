using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TragicPortal : MonoBehaviour
{
    public bool used;
    public Animator anim;
    public AudioClip tpSound;

    private void OnTriggerEnter(Collider other)
    {
        if (!used)
        {
            used = true;
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        AudioSource mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();

        Time.timeScale = 0f;
        anim.Play("In");
        mainMus.PlayOneShot(tpSound);
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene("FinaleChecker");
        Time.timeScale = 1f;
    }
}
