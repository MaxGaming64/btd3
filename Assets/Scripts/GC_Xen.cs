using UnityEngine;
using UnityEngine.SceneManagement;

public class GC_Xen : MonoBehaviour
{
    public bool paused;
    private float timeToRandomAmb = -1f;
    public GameObject pauseCanvas;
    private AudioSource mainMus;
    public DialogueSystem ds;
    public AudioClip ambient;
    public AudioClip alien_squit;
    public Animator fade;
    public GameObject chapter;

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

            fade.Play("Out");
        }

        else
        {
            mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();
        }

        chapter.GetComponent<TMPro.TextMeshProUGUI>().text = "Xen";
        chapter.GetComponent<Animator>().Play("NewChapter");
    }

    void Update()
    {
        if (timeToRandomAmb < 0f)
        {
            timeToRandomAmb = Random.Range(alien_squit.length, 30);
            mainMus.PlayOneShot(alien_squit);
        }

        if (timeToRandomAmb > 0f)
        {
            timeToRandomAmb -= Time.deltaTime;
        }
        
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
