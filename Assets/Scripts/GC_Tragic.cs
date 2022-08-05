using System.Collections;
using UnityEngine;

public class GC_Tragic : MonoBehaviour
{
    private AudioSource mainMus;
    public DialogueSystem ds;
    public AudioClip ambient;
    public AudioClip finale1_lp;
    public AudioClip finale2;
    public Animator fade;
    public GameObject chapter;
    public GameObject joe;

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
        FindObjectOfType<PauseManager>().allowPause = !ds.dialogue & !joe.GetComponent<TragicJoe>().killing;

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
        yield return new WaitForSecondsRealtime(finale1_lp.length - mainMus.time);
        mainMus.loop = true;
        mainMus.clip = finale2;
        mainMus.Play();
    }
}
