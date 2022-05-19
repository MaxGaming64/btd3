using UnityEngine;

public class SkyCamera : MonoBehaviour
{
    public float moveSpeed;
    
    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.localPosition = Camera.main.transform.position / moveSpeed;
    }
}
