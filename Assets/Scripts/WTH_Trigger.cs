using UnityEngine;

public class WTH_Trigger : MonoBehaviour
{
    private bool used;
    public int dialogeType;
    public DialogueSystem dialogeSystem;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") & !used)
        {
            used = true;
            dialogeSystem.StartDialoge(dialogeType);
        }
    }
}