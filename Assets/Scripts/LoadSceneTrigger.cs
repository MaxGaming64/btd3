using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTrigger : MonoBehaviour
{
    public string scene;
    public Transform landmark;

    private void OnTriggerEnter(Collider other)
    {
        if (landmark != null)
        {
            Transform player = FindObjectOfType<Player>().transform;

            LandmarkKeeper.CreateLandmarkKeeper(landmark.position - player.position, player.eulerAngles);
            SceneManager.LoadScene(scene);
        }
    }
}
