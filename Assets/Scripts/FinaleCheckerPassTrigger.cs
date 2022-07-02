using UnityEngine;

public class FinaleCheckerPassTrigger : MonoBehaviour
{
    public FinaleChecker gc;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gc.Pass();
        }
    }
}
