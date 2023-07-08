using UnityEngine;

public class AlienSpawnTrigger : MonoBehaviour
{
    private bool used;
    private AudioSource enemyAudio;
    public GameObject enemy;

    private void Start()
    {
        enemyAudio = enemy.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!used)
        {
            used = true;
            enemy.SetActive(true);
            enemyAudio.PlayOneShot((AudioClip)Resources.Load("sounds/beamstart2"));
            enemyAudio.PlayOneShot((AudioClip)Resources.Load("sounds/beamstart7"));
        }
    }
}
