using System.Collections;
using UnityEngine;
using BTD3Framework;

public class GC_Tragic : BaseGameController
{
    private AudioSource mainMus;
    public AudioClip ambient;
    public AudioClip creepyHigh;
    public AudioClip finale1;
    public AudioClip finale2;
    public Animator fade;
    public GameObject chapter;
    public GameObject creepyHighCam;
    public GameObject joe;

    void Start()
    {
        Init(3, chapter, "The Union", fade);
        mainMus = InitMainMus(ambient);
    }

    void Update()
    {
        pm.allowPause = !(ds.dialogue && joe.GetComponent<TragicJoe>().killing);

        if (joe.activeSelf)
        {
            joe.transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        }
    }

    IEnumerator CreepyHigh()
    {
        player.gameObject.SetActive(false);
        creepyHighCam.SetActive(true);
        MainMus.SetMainMus(creepyHigh, 1f, 1f, false);
        mainMus.gameObject.AddComponent<PauseAudio>();
        yield return new WaitForSeconds(creepyHigh.length);
        player.gameObject.SetActive(true);
        creepyHighCam.SetActive(false);
        MainMus.SetMainMus(ambient);
        Destroy(mainMus.gameObject.GetComponent<PauseAudio>());
    }

    public void StartChaos()
    {
        joe.SetActive(true);
        MainMus.SetMainMus(finale1);
    }

    public IEnumerator ContinueChaos()
    {
        yield return new WaitForSecondsRealtime(finale1.length - mainMus.time);
        MainMus.SetMainMus(finale2);
    }
}
