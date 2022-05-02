using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    public bool follow;
    private NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (follow)
        {
            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        }

        else
        {
            agent.ResetPath();
        }
    }
}
