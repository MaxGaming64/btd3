using UnityEngine;

public class GC_Finale : MonoBehaviour
{
    private AudioSource mainMus;
    public AudioClip mus_finale;
    public DialogeSystem ds;

    void Start()
    {
        ds.StartDialoge(99);

        if (GameObject.FindGameObjectWithTag("MainMus") == null)
        {
            mainMus = new GameObject().AddComponent<AudioSource>();
            mainMus.gameObject.name = "MainMus";
            mainMus.gameObject.tag = "MainMus";
            mainMus.volume = 0.7f;
            mainMus.loop = true;
            mainMus.clip = mus_finale;
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
        
    }
}