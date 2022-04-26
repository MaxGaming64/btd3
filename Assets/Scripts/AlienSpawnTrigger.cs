using UnityEngine;

public class AlienSpawnTrigger : MonoBehaviour
{
    private bool used;
    public GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (!used)
        {
            used = true;
            
            AudioSource enemyAudio = enemy.GetComponent<AudioSource>();
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();

            audioSource.spatialBlend = 1f;
            audioSource.minDistance = 10f;
            audioSource.maxDistance = 20f;
            audioSource.rolloffMode = AudioRolloffMode.Linear;
            audioSource.dopplerLevel = 0f;
            audioSource.pitch = 1.2f;

            enemy.SetActive(true);
            audioSource.PlayOneShot((AudioClip)Resources.Load("sounds/beamstart2"));
            enemyAudio.PlayOneShot((AudioClip)Resources.Load("sounds/beamstart7"));
        }
    }
}
