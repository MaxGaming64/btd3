using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTrigger : MonoBehaviour
{
    public string scene;
    public bool async;
    public Transform landmark;

    private void OnTriggerEnter(Collider other)
    {
        if (landmark != null)
        {
            Transform player = FindObjectOfType<BasePlayer>().transform;
            LandmarkKeeper.CreateLandmarkKeeper(landmark.position - player.position, player.eulerAngles);
            
            if (async)
            {
                SceneManager.LoadSceneAsync(scene);
            }

            else
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
