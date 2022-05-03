using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("chapter") == 0)
        {
            PlayerPrefs.SetInt("chapter", 1);
        }

        if (Application.CanStreamedLevelBeLoaded("Menu" + PlayerPrefs.GetInt("chapter")))
        {
            SceneManager.LoadSceneAsync("Menu" + PlayerPrefs.GetInt("chapter"));
        }

        else
        {
            SceneManager.LoadSceneAsync("Menu1");
        }
    }
}
