using System.Collections;
using UnityEngine;
using BTD3Framework;

public class GC_Tragic : BaseGameController
{
    private AudioSource mainMus;
    public AudioClip ambient;
    public AudioClip finale1;
    public AudioClip finale2;
    public Animator fade;
    public GameObject chapter;
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
