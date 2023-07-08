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
    private AudioSource audioSource;
    public Animator anim;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

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
        if (changeTimeScale)
        {
            Time.timeScale = newTimeScale;
        }

        anim.Play("In");
        audioSource.PlayOneShot((AudioClip)Resources.Load("sounds/beamstart10"));
        
        if (tpWhilePaused)
        {
            yield return new WaitForSecondsRealtime(1.5f);
            PlaySuckSound();
            yield return new WaitForSecondsRealtime(3.5f);
        }

        else
        {
            yield return new WaitForSeconds(1.5f);
            PlaySuckSound();
            yield return new WaitForSeconds(3.5f);
        }

        SceneManager.LoadScene(newScene);
        Time.timeScale = 1f;
    }

    void PlaySuckSound()
    {
        audioSource.PlayOneShot((AudioClip)Resources.Load("sounds/port_suckout1"), 3f);
    }
}
