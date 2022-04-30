using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XenEndingTrigger : MonoBehaviour
{
    public Animator anim;
    public AudioClip tpSound;
    
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        AudioSource mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();

        anim.Play("In");
        mainMus.PlayOneShot(tpSound);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("YTDemoEnd");
        Destroy(mainMus.gameObject);
    }
}
