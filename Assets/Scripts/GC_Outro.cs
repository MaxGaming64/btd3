using UnityEngine;
using UnityEngine.SceneManagement;

public class GC_Outro : MonoBehaviour
{
    public bool paused;
    public GameObject pauseCanvas;
    private AudioSource mainMus;
    public DialogueSystem ds;
    public AudioClip ambient;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("MainMus") == null)
        {
            mainMus = GameControllerScript.CreateMainMus(ambient);
        }

        else
        {
            mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();
            mainMus.loop = true;

            if (mainMus.clip != ambient)
            {
                mainMus.clip = ambient;
                mainMus.Play();
            }
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause") & !ds.dialogue)
        {
            if (paused)
            {
                paused = false;
                Time.timeScale = 1f;
                pauseCanvas.SetActive(false);
            }

            else
            {
                paused = true;
                Time.timeScale = 0f;
                pauseCanvas.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) & paused)
        {
            Time.timeScale = 1f;
            Destroy(mainMus.gameObject);
            SceneManager.LoadScene("MenuOutro");
        }
    }
}
