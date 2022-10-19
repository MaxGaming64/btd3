using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AlienSlave : MonoBehaviour
{
    public bool playerSeen;
    public bool attacking;
    private bool alertSoundPlayed;
    private NavMeshAgent agent;
    private AudioSource audioSource;
    private Transform player;
    public GameObject[] wanderPoints;
    public AudioClip[] alert;
    public AudioClip attack;
    public AudioClip zap;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.SetDestination(wanderPoints[Random.Range(0, wanderPoints.Length)].transform.position);
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.up * 2f, direction, out hit, 10f, 3, QueryTriggerInteraction.Ignore) && hit.transform.CompareTag("Player"))
        {
            playerSeen = true;

            if (!alertSoundPlayed)
            {
                alertSoundPlayed = true;
                
                if (!attacking)
                {
                    audioSource.PlayOneShot(alert[Random.Range(0, alert.Length)]);
                }
            }

            agent.SetDestination(player.transform.position);
        }

        else
        {
            playerSeen = false;
            alertSoundPlayed = false;
        }

        if (agent.remainingDistance < 1 & !playerSeen)
        {
            agent.SetDestination(wanderPoints[Random.Range(0, wanderPoints.Length)].transform.position);
        }

        if (playerSeen & !attacking)
        {
            StartCoroutine(Attack());
        }

        if (attacking)
        {
            agent.speed = 0f;
        }

        else
        {
            agent.speed = 5f;
        }
    }

    IEnumerator Attack()
    {
        attacking = true;
        audioSource.PlayOneShot(attack);
        yield return new WaitForSeconds(1.5f);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GC_Xen>().playerHealth -= 20;
        audioSource.PlayOneShot(zap);
        yield return new WaitForSeconds(zap.length + 1f);
        attacking = false;
    }
}
