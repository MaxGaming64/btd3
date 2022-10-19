using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public GC_Mansion gc;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") & gc.lockDoor01_open)
        {
            gc.FallDown();
            Destroy(gameObject);
        }
    }
}