using System.Collections;
using UnityEngine;
using BTD3Framework;

public class GC_Finale : BaseGameController
{
    private bool bossPause;
    public bool knockout;
    public int stage;
    public GameObject hud;
    public GameObject chapter;
    public GameObject dlg99;
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
        Init(4);
        InitMainMus(mus_finale, 0.7f);

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
        pm.allowPause = !ds.dialogue && !joe.killing;

        Player playerScript = player.GetComponent<Player>();
        
        if (bossPause)
        {
            playerScript.enabled = false;
            
            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
            
            player.position = Vector3.Lerp(player.position, new Vector3(15f, 10f, -270f), Time.deltaTime * 2f);
            player.rotation = Quaternion.Lerp(player.rotation, rotation, Time.deltaTime * 2f);
            playerScript.cameraScript.transform.localRotation = Quaternion.Lerp(playerScript.cameraScript.transform.localRotation, Quaternion.identity, Time.deltaTime * 2f);

            if (!knockout)
            {
                joe.transform.position = Vector3.Lerp(joe.transform.position, new Vector3(75f, 10f, -270f), Time.deltaTime * 2f);
            }

            else
            {
                joe.transform.position = Vector3.Lerp(joe.transform.position, new Vector3(25f, 10f, -270f), Time.deltaTime * 2f);
                joeSprite.transform.rotation = Quaternion.RotateTowards(joeSprite.transform.rotation, Quaternion.Euler(new Vector3(0f, 90f, 0f)), Time.deltaTime * 5f);

                if (joeSprite.transform.rotation.eulerAngles.x <= 0.1f)
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

        if (joe.killing && joeSprite.sprite != joeRedSprite)
        {
            joeSprite.sprite = joeRedSprite;
        }
    }

    public IEnumerator StartBossIntro()
    {
        bossPause = true;
        MainMus.SetMainMus(mus_bossintro, 0.7f);
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
                MainMus.SetMainMus(mus_bossmain1);
                break;
            case 1:
                MainMus.SetMainMus(mus_bossmain2);
                break;
            case 2:
                MainMus.SetMainMus(mus_bossmain3);
                break;
            case 3:
                baldi.SetActive(false);
                finaleBaldi.SetActive(true);
                joeSprite.sprite = joeAngrySprite;
                MainMus.SetMainMus(mus_bossfinale1, 0.7f);
                ds.StartDialogue(101);
                break;
        }

        stage++;
    }

    public void Knockout()
    {
        knockout = true;
        bossPause = true;
        MainMus.SetMainMus(mus_bossknockout);
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
        MainMus.SetMainMus(mus_bossprepare);
        joeSprite.sprite = joeBlueSprite;
        joeSprite.GetComponent<BillboardY>().enabled = true;
        yield return new WaitForSeconds(mus_bossprepare.length);
        StartMainBattle();
    }
}
