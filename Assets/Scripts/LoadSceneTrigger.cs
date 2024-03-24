using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneTrigger : MonoBehaviour
{
    public string scene;
    public Transform landmark;

    private void OnTriggerEnter(Collider other)
    {
        if (landmark != null)
        {
            Transform player = FindObjectOfType<BasePlayer>().transform;
            LandmarkKeeper.CreateLandmarkKeeper(landmark.position - player.position, player.eulerAngles);

            foreach (var image in FindObjectsOfType<Image>(true))
            {
                if (image.name == "Loading")
                {
                    image.gameObject.SetActive(true);
                }
            }

            SceneManager.LoadScene(scene);
        }
    }
}
