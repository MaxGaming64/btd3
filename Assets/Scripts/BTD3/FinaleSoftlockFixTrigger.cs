using UnityEngine;

public class FinaleSoftlockFixTrigger : MonoBehaviour
{
    public CharacterController player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.enabled = false;
            player.transform.position = new Vector3(15f, 10f, -270f);
            player.transform.rotation = Quaternion.identity;
            player.enabled = true;
        }
    }
}
