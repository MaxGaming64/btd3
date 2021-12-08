using System.Collections;
using UnityEngine;

public class GC_Finale : MonoBehaviour
{
    private bool bossPause;
    public bool paused;
    public GameObject pauseCanvas;
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
    public GameObject barrier;

    private void Start()
    {
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

        if (PlayerPrefs.GetInt("respawn") == 1)
        {
            mainMus.clip = mus_bossfinale2;
            mainMus.volume = 0.1f;
            mainMus.Play();
            player.GetComponent<Player>().enabled = false;
            player.position = new Vector3(15f, 10f, -270f);
            player.rotation = Quaternion.Euler(0f, 90f, 0f);
            PlayerPrefs.SetInt("respawn", 0);
        }

        else
        {
            ds.StartDialoge(99);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause") & !ds.dialogue & !joe.killing)
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
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(StartBossIntro());
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
        barrier.SetActive(true);
    }
    
    private void StartMainBattle(int type)
    {
        bossPause = false;
        player.GetComponent<Player>().enabled = true;
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
