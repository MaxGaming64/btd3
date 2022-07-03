using UnityEngine;

public class JumpHighTrigger : MonoBehaviour
{
    public bool jumpHigh;
    public KnockoutTrigger knockoutTrigger;
    public GC_Finale gc;
    public AudioSource gelAudio;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (jumpHigh)
            {
                if (gc.stage != 4)
                {
                    knockoutTrigger.allowKnockout = true;
                }
            }
            
            else
            {
                jumpHigh = true;
            }
        }
    }
}
