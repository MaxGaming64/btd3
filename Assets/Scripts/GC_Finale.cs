using System.Collections;
using UnityEngine;

public class GC_Finale : MonoBehaviour
{
    private bool bossPause;
    public bool paused;
    public bool knockout;
    public int stage;
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
    public Sprite joeAngrySprite;
    public GameObject barrier;
    public GameObject aiBaldi;
    public GameObject baldi;
    public GameObject finaleBaldi;
    public Animator elev;

    private void Start()
    {
        if (PlayerPrefs.GetInt("chapter") < 4)
        {
            PlayerPrefs.SetInt("chapter", 4);
        }

        if (GameObject.FindGameObjectWithTag("MainMus") == null)
        {
            mainMus = GameControllerScript.CreateMainMus(mus_finale, 0.7f);
        }

        else
        {
            mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();
            mainMus.loop = true;
            mainMus.volume = 0.7f;
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
            playerScript.Camera.localRotation = Quaternion.Lerp(playerScript.Camera.localRotation, Quaternion.identity, Time.deltaTime * 2f);

            if (!knockout)
            {
                joe.transform.position = Vector3.Lerp(joe.transform.position, new Vector3(75f, 10f, -270f), Time.deltaTime * 2f);
            }

            else
            {
                joe.transform.position = Vector3.Lerp(joe.transform.position, new Vector3(25f, 10f, -270f), Time.deltaTime * 2f);
                joeSprite.transform.rotation = Quaternion.Lerp(joeSprite.transform.rotation, Quaternion.Euler(new Vector3(0f, 90f, 1f)), Time.deltaTime * 0.1f);

                if (joeSprite.transform.rotation.eulerAngles.x <= 10f)
                {
                    if (stage == 3)
                    {
                        StartMainBattle();
                        joeSprite.GetComponent<BillboardY>().enabled = true;
                    }

                    else
                    {
                        StartCoroutine(Prepare());
                    }
                }
            }
        }
    }

    public IEnumerator StartBossIntro()
    {
        bossPause = true;
        mainMus.clip = mus_bossintro;
        mainMus.volume = 0.5f;
        mainMus.Play();
        yield return new WaitForSeconds(16f);
        StartMainBattle();
        barrier.SetActive(true);
    }
    
    private void StartMainBattle()
    {
        bossPause = false;
        player.GetComponent<Player>().enabled = true;
        joe.attacking = true;
        joeSprite.sprite = joeRedSprite;

        switch (stage)
        {
            case 0:
                elev.enabled = true;
                aiBaldi.SetActive(false);
                baldi.SetActive(true);
                mainMus.clip = mus_bossmain1;
                mainMus.Play();
                break;
            case 1:
                mainMus.clip = mus_bossmain2;
                mainMus.Play();
                break;
            case 2:
                mainMus.clip = mus_bossmain3;
                mainMus.Play();
                break;
            case 3:
                baldi.SetActive(false);
                finaleBaldi.SetActive(true);
                joeSprite.sprite = joeAngrySprite;
                mainMus.volume = 0.7f;
                mainMus.clip = mus_bossfinale1;
                mainMus.Play();
                ds.StartDialogue(101);
                break;
        }

        stage++;
    }

    public void Knockout()
    {
        knockout = true;
        bossPause = true;
        mainMus.clip = mus_bossknockout;
        mainMus.Play();
        joe.attacking = false;
        joe.transform.rotation = Quaternion.identity;
        joeSprite.GetComponent<BillboardY>().enabled = false;
        joeSprite.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
        joeSprite.sprite = joeNoneSprite;
    }

    private IEnumerator Prepare()
    {
        knockout = false;
        bossPause = true;
        mainMus.clip = mus_bossprepare;
        mainMus.Play();
        joeSprite.sprite = joeBlueSprite;
        joeSprite.GetComponent<BillboardY>().enabled = true;
        yield return new WaitForSeconds(mus_bossprepare.length);
        StartMainBattle();
    }
}
