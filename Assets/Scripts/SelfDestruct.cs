using System.Collections;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float lifespan;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }
}