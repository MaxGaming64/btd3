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

        SceneManager.LoadSceneAsync("Menu" + PlayerPrefs.GetInt("chapter"));
    }
}
