using System.Collections;
using UnityEngine;

public class GC_Tragic : MonoBehaviour
{
    private AudioSource mainMus;
    public DialogueSystem ds;
    public AudioClip ambient;
    public AudioClip finale1_lp;
    public AudioClip finale2;
    public AudioClip finale2_lp;
    public Animator fade;
    public GameObject chapter;
    public GameObject joe;
    public PortalTrigger portal;

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
        FindObjectOfType<PauseManager>().allowPause = !ds.dialogue & !joe.GetComponent<TragicJoe>().killing & !portal.used;

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
        if (!mainMus.isPlaying) yield break;
        mainMus.loop = true;
        mainMus.clip = finale2_lp;
        mainMus.Play();
    }
}
