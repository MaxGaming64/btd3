using UnityEngine;
using UnityEngine.SceneManagement;

public class GC_Xen : MonoBehaviour
{
    public bool paused;
    public GameObject pauseCanvas;
    private AudioSource mainMus;
    public DialogueSystem ds;
    public AudioClip ambient;

    void Start()
    {
        if (PlayerPrefs.GetInt("chapter") < 2)
        {
            PlayerPrefs.SetInt("chapter", 2);
        }
        
        if (GameObject.FindGameObjectWithTag("MainMus") == null)
        {
            mainMus = new GameObject().AddComponent<AudioSource>();
            mainMus.gameObject.name = "MainMus";
            mainMus.gameObject.tag = "MainMus";
            mainMus.loop = true;
            mainMus.clip = ambient;
            mainMus.Play();
            DontDestroyOnLoad(mainMus);
        }

        else
        {
            mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();
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
    }
}
