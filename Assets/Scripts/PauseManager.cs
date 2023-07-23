using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool paused;
    public bool allowPause;
    private bool silenceAudio;
    public string menuScene;
    public GameObject pauseMenu;

    void Start()
    {
        silenceAudio = PlayerPrefs.GetInt("pauseAudio") == 1;
    }

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
                AudioListener.pause = silenceAudio;
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

            /*else if (Input.GetKeyDown(KeyCode.T))
            {
                silenceAudio = !silenceAudio;

                if (silenceAudio)
                {
                    PlayerPrefs.SetInt("pauseAudio", 1);
                    AudioListener.pause = true;
                }

                else
                {
                    PlayerPrefs.SetInt("pauseAudio", 0);
                    AudioListener.pause = false;
                }
            }*/
        }
    }
}
