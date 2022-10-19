using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoidTrigger : MonoBehaviour
{
    public Animator fade;
    
    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fade.Play("In");
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
