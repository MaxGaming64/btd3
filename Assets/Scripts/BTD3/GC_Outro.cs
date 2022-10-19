using UnityEngine;

public class GC_Outro : MonoBehaviour
{
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
            mainMus.volume = 1f;

            if (mainMus.clip != ambient)
            {
                mainMus.clip = ambient;
                mainMus.Play();
            }
        }
    }

    void Update()
    {
        FindObjectOfType<PauseManager>().allowPause = !ds.dialogue;
    }
}
