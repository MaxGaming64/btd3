using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class TestJoe : MonoBehaviour
{
    public bool killing;
    private NavMeshAgent agent;
    public Transform player;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > 5f)
        {
            agent.speed = 70f;
        }

        else
        {
            agent.speed = 5f;
        }

        agent.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") & !killing)
        {
            killing = true;
            //PlayerPrefs.SetInt("hasEverCheckedFinale", 1);
            PlayerPrefs.SetInt("finaleFix", 1);
            SceneManager.LoadSceneAsync("Warning");
        }
    }
}
