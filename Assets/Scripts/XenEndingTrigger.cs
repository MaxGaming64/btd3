using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XenEndingTrigger : MonoBehaviour
{
    private bool used;
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

        anim.Play("In");
        mainMus.PlayOneShot(tpSound);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Chapter3");
    }
}
