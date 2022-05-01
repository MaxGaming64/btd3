using UnityEngine;
using UnityEngine.SceneManagement;

public class GC_Tragic : MonoBehaviour
{
    public bool paused;
    public GameObject pauseCanvas;
    private AudioSource mainMus;
    public DialogueSystem ds;
    public AudioClip ambient;
    public Animator fade;
    public GameObject chapter;

    void Start()
    {
        if (PlayerPrefs.GetInt("chapter") < 3)
        {
            PlayerPrefs.SetInt("chapter", 3);
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

            if (mainMus.clip != ambient)
            {
                mainMus.clip = ambient;
                mainMus.Play();
            }
        }

        fade.Play("Out");

        chapter.GetComponent<TMPro.TextMeshProUGUI>().text = "The Unition";
        chapter.GetComponent<Animator>().Play("NewChapter");
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
            SceneManager.LoadScene("MenuLoader");
        }
    }
}
