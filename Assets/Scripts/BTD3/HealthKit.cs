using UnityEngine;

public class HealthKit : MonoBehaviour
{
    private GC_Xen gc;
    public AudioClip heal;

    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GC_Xen>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gc.playerHealth < 100)
        {
            gc.playerHealth += 20;
            GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>().PlayOneShot(heal, 2f);
            Destroy(gameObject);
        }
    }
}
