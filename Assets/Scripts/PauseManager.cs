using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool paused;
    public bool allowPause;
    public string menuScene;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetButtonDown("Pause") && allowPause)
        {
            if (paused)
            {
                paused = false;
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                AudioListener.pause = false;
            }

            else
            {
                paused = true;
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
            }
        }

        if (paused)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Time.timeScale = 1f;
                Destroy(GameObject.FindGameObjectWithTag("MainMus"));
                SceneManager.LoadScene(menuScene);
            }
        }
    }
}
