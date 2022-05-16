using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GC_Tragic : MonoBehaviour
{
    public bool paused;
    public GameObject pauseCanvas;
    private AudioSource mainMus;
    public DialogueSystem ds;
    public AudioClip ambient;
    public AudioClip finale1_lp;
    public AudioClip finale2;
    public AudioClip finale2_lp;
    public Animator fade;
    public GameObject chapter;
    public GameObject joe;
    public TragicPortal portal;

    void Start()
    {
        if (PlayerPrefs.GetInt("chapter") < 3)
        {
            PlayerPrefs.SetInt("chapter", 3);
        }

        if (GameObject.FindGameObjectWithTag("MainMus") == null)
        {
            mainMus = GameControllerScript.CreateMainMus(ambient);
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
        if (Input.GetButtonDown("Pause") & !ds.dialogue & !joe.GetComponent<TragicJoe>().killing & !portal.used)
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

        if (joe.activeSelf)
        {
            joe.transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        }
    }

    public void StartChaos()
    {
        joe.SetActive(true);
        mainMus.clip = finale1_lp;
        mainMus.Play();
    }

    public IEnumerator ContinueChaos()
    {
        mainMus.loop = false;
        mainMus.clip = finale2;
        mainMus.Play();
        yield return new WaitForSecondsRealtime(finale2.length);
        mainMus.loop = true;
        mainMus.clip = finale2_lp;
        mainMus.Play();
    }
}
