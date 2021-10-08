using UnityEngine;

public class WTH_Trigger : MonoBehaviour
{
    private bool used;
    public int dialogeType;
    public GC_Mansion gc;
    public DialogeSystem dialogeSystem;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") & !used)
        {
            used = true;
            dialogeSystem.StartDialoge(dialogeType);
        }
    }
}