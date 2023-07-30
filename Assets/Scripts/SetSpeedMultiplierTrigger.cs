using UnityEngine;

public class SetSpeedMultiplierTrigger : MonoBehaviour
{
    public float speedMultiplier;
    private BasePlayer player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.movementScript.SetSpeedMultiplier(speedMultiplier);
        }
    }
}
