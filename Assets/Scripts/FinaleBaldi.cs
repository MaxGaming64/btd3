using UnityEngine;

public class FinaleBaldi : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = player.position - Vector3.forward * 5f;
    }
}
