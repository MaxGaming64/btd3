using UnityEngine;
using UnityEngine.AI;

public class Joe : MonoBehaviour
{
    public bool attacking;
    private GC_Finale gc;
    private NavMeshAgent agent;
    
    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GC_Finale>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (attacking)
        {
            agent.SetDestination(gc.player.position);
        }
    }
}
