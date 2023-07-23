using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private bool used;
    public int dialogeType;
    public DialogueSystem dialogeSystem;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !used)
        {
            used = true;
            dialogeSystem.StartDialogue(dialogeType);
        }
    }
}