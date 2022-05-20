using UnityEngine;

public class SkyCamera : MonoBehaviour
{
    public float skyScale;
    
    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.localPosition = Camera.main.transform.position / skyScale;
    }
}
