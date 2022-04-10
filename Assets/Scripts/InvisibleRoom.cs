using UnityEngine;

public class InvisibleRoom : MonoBehaviour
{
    public GameObject room;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            room.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            room.SetActive(false);
        }
    }
}
