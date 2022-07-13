using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    public bool used;
    public bool tpWhilePaused;
    public bool changeTimeScale;
    public float newTimeScale;
    public string newScene;
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

        if (changeTimeScale)
        {
            Time.timeScale = newTimeScale;
        }

        anim.Play("In");
        mainMus.PlayOneShot(tpSound);
        
        if (tpWhilePaused)
        {
            yield return new WaitForSecondsRealtime(5f);
        }

        else
        {
            yield return new WaitForSeconds(5f);
        }

        SceneManager.LoadScene(newScene);
        Time.timeScale = 1f;
    }
}
