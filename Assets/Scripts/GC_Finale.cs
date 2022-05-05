using System.Collections;
using UnityEngine;

public class GC_Finale : MonoBehaviour
{
    private bool bossPause;
    public bool paused;
    public GameObject hud;
    public GameObject pauseCanvas;
    public GameObject chapter;
    public GameObject dlg99;
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
    public Animator elev;

    private void Start()
    {
        if (PlayerPrefs.GetInt("chapter") < 4)
        {
            PlayerPrefs.SetInt("chapter", 4);
        }

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
            mainMus.clip = mus_finale;
            mainMus.Play();
        }

        if (PlayerPrefs.GetInt("respawn") == 1)
        {
            dlg99.SetActive(false);
            player.GetComponent<Player>().enabled = false;
            player.position = new Vector3(15f, 10f, -270f);
            player.rotation = Quaternion.Euler(0f, 90f, 0f);
            PlayerPrefs.SetInt("respawn", 0);
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
            UnityEngine.SceneManagement.SceneManager.LoadScene("MenuLoader");
        }

        Player playerScript = player.GetComponent<Player>();
        
        if (bossPause)
        {
            playerScript.enabled = false;
            
            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
            
            player.position = Vector3.Lerp(player.transform.position, new Vector3(15f, 10f, -270f), Time.deltaTime * 2f);
            player.rotation = Quaternion.Lerp(player.transform.rotation, rotation, Time.deltaTime * 2f);
            playerScript.Camera.localRotation = Quaternion.identity;
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
            elev.enabled = true;
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
        player.GetComponent<Player>().enabled = false;
        mainMus.clip = mus_bossknockout;
        mainMus.Play();
        joeSprite.sprite = joeNoneSprite;
        joe.GetComponent<Billboard>().enabled = false;
    }

    private IEnumerator Prepare(int forWhat)
    {
        bossPause = true;
        mainMus.clip = mus_bossprepare;
        mainMus.Play();
        joeSprite.sprite = joeBlueSprite;
        joe.GetComponent<Billboard>().enabled = false;
        yield return new WaitForSeconds(mus_bossprepare.length);
        StartMainBattle(forWhat);
    }
}
