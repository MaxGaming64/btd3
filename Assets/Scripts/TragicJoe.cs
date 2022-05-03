using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TragicJoe : MonoBehaviour
{
    public bool killing;
    public Animator fade;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Kill());
        }
    }

    IEnumerator Kill()
    {
        killing = true;
        Time.timeScale = 0f;
        fade.Play("In");
        GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
