using UnityEngine;

public class KnockoutTrigger : MonoBehaviour
{
    public bool allowKnockout;
    public GC_Finale gc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && allowKnockout)
        {
            allowKnockout = false;
            gc.Knockout();
        }
    }
}
