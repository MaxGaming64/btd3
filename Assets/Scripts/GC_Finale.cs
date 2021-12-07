using UnityEngine;
using System.Collections;

public class GC_Finale : MonoBehaviour
{
    private bool bossPause;
    private AudioSource mainMus;
    public AudioClip mus_finale;
    public AudioClip mus_bossintro;
    public AudioClip mus_bossmain1;
    public AudioClip mus_bossmain2;
    public AudioClip mus_bossmain3;
    public AudioClip mus_bossknockout;
    public AudioClip mus_bossprepare;
    public AudioClip mus_bossfinale1;
    public AudioClip mus_bossfinale2;
    public AudioClip mus_bossfinale3;
    public DialogueSystem ds;
    public Transform player;
    public Joe joe;
    public SpriteRenderer joeSprite;
    public Sprite joeRedSprite;
    public Sprite joeBlueSprite;
    public Sprite joeNoneSprite;

    private void Start()
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

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine("StartBossIntro");
        }
#endif

        Player playerScript = player.GetComponent<Player>();
        
        if (bossPause)
        {
            playerScript.enabled = false;
            
            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
            
            player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(15f, 10f, -270f), Time.deltaTime * 2f);
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, rotation, Time.deltaTime * 2f);
        }

        else
        {
            playerScript.enabled = true;
        }
    }

    private IEnumerator StartBossIntro()
    {
        bossPause = true;
        mainMus.clip = mus_bossintro;
        mainMus.volume = 0.5f;
        mainMus.Play();
        yield return new WaitForSeconds(16f);
        StartMainBattle(0);
        joeSprite.sprite = joeRedSprite;
    }
    
    private void StartMainBattle(int type)
    {
        bossPause = false;
        joe.attacking = true;
        joeSprite.sprite = joeRedSprite;
        
        if (type == 0)
        {
            mainMus.clip = mus_bossmain1;
            mainMus.Play();
        }

        else if (type == 1)
        {
            mainMus.clip = mus_bossmain2;
            mainMus.Play();
        }

        else if (type == 2)
        {
            mainMus.clip = mus_bossmain3;
            mainMus.Play();
        }
    }

    private void Knockout()
    {
        mainMus.clip = mus_bossknockout;
        mainMus.Play();
        joeSprite.sprite = joeNoneSprite;
    }
}
