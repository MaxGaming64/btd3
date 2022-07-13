using UnityEngine;

public class SetSpeedMultiplierTrigger : MonoBehaviour
{
    public float speedMultiplier;
    private Player player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.movementScript.SetSpeedMultiplier(speedMultiplier);
        }
    }
}
