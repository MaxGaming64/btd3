using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    private int slideCount;
    private int dialogueType;
    public bool dialogue;
    private string[] introDialogue = new string[5]
    {
        "...and you went to his house.",
        "Principal told you his address,",
        "So you ask Principal where he lives.",
        "You search for him, and no luck...",
        "But then, you realize that Baldi is not there."
    };
    private string[] dialogue01 = new string[2]
    {
        "But I think I need to find the key to the door first...",
        "Oh, wait! There's a locked door there!"
    };
    private string[] dialogue02 = { "Let me get a closer look..." };
    private string[] dialogue03 = new string[2]
    {
        "I think I'm in some kind of vent...",
        "I've gotta get the hell outta here!"
    };
    private string[] dialogue04 = new string[5]
    {
        "Off you go into the secret, unknown place.",
        "Wait a minute, what's that sound?!",
        "Alright, let's try going there.",
        "Wait, there's an opening here; how did I not notice it?",
        "Let's see if there's a way to get outta here."
    };
    private string[] dialogue05 = new string[10]
    {
        "<i>Hmm, it's gonna take him a long time, huh? Then, let's escape!", //0
        "Let me think... I gotta make up a really huge plan...", //1
        "Hmm...", //2
        "So what are you gonna do to me?", //3
        "<color=red>Oh yes!", //4
        "Oh no...", //5
        "Well yes, of course, idiot!", //6
        "Is that... Joe?", //7
        "Ready for a deadly chainsaw?", //8
        "Hold on, who--" //9
    };
    private string[] dialogue06 = new string[2]
    {
        "I need to find some food, though... I'm starving...",
        "Well, I won't see Joe for a long time, that's for sure!"
    };
    private string[] dialogue07 = new string[7]
    {
        "Don't worry, Baldi! I'll save you!", //0
        "BUT BE CAREFUL, THERE ARE DANGEROUS ALIENS THERE!", //1
        "TO SAVE ME, YOU MUST GO THROUGH PLANET XEN!", //2
        "Oh no! How can I save you?!", //3
        "YES, AND I'M KIDNAPPED BY JOE!!!", //4
        "What?? Is that Baldi?!", //5
        "HELP!!!!!!" //6
    };
    private string[] dialogue08 = new string[2]
    {
        "I gotta get outta here soon...",
        "And what was that alien?"
    };
    private string[] dialogue09 = new string[3]
    {
        "Speaking of Baldi, where is he?",
        "And why does he even have this in the first place??",
        "Why did Baldi never tell us about this?"
    };
    private string[] dialogue10 =
    {
        "I don't know...", //0
        "Okay. But what if Joe finds us?", //1
        "We have to go further, and escape out of here.", //2
        "So what are we gonna go now?", //3
        "I decided to check it out myself.", //4
        "After you told me Baldi was gone...", //5
        "But wait, Principal, what are you doing here?", //6
        "I'm so glad you made it through Xen!", //7
        "Player!", //8
        "Principal?!", //9
    };
    private string[] dialogue11 =
    {
        "RUN!!!", //0
        "Correction: I'M going to kill ALL OF YOU!!!", //1
        "I'M GONNA KILL YOU FOR THAT!!!", //2
        "He stole it while I was in your brain.", //3
        "Wait, are you slapping with MY ruler?!", //4
        "Oh no... He found us!" //5
    };
    private string[] dialogue12 =
    {
        "NOOOOOO!",
        "Go on without me! I'll survive!",
        "We can't leave you here, Principal!"
    };
    private string[] dialogue99_0 = new string[3] //finale intro
    {
        "I think so...",
        "So do we just try to find him?",
        "I think this is where Joe lives."
    };
    private string[] dialogue99_1 = //finale bossbattle intro
    {
        "Okay...", //0
        "I believe in you!", //1
        "I must stay back.", //2
        "Listen, Player, I can't fight with you...", //3
        "Uh oh...", //4
        "<color=red>EVERTHING GOES CRAZY!", //5
        "When it's a finale...", //6
        "This is the finale...", //7
        "Because...", //8
        "Why are your eyes blue?" //9
    };
    private string[] dialogue99_2 = //finale outro 1
    {
        "Let's check it out!", //baldi sad, 0
        "It's coming from the top!", //player, 1
        "Wait, what's that noise?", //baldi, 2
        "<i>*sigh*</i>", //baldi sad, 3
        "You're right.", //baldi sad, 4
        "Baldi, we are about to die and you are <i>HAPPY?!</i>", //player, 5
        "HA HA HA!!!", //baldi evil, 6
        "No no no NO NO NO!!!!!!", //joe mad, 7
        "No.", //joe mad, 8
        "WAIT.", //joe mad, 9
        "Wait.", //joe mad, 10
        "Wait, but won't you die too?", //player, 11
        "So you all DIE!!!", //joe happy, red, 12
        "Good luck with that, I set up a bomb here!", //joe happy, 13
        "We must escape from his deadly chainsaw!", //player, 14
        "It's too early to celebrate!", //player, 15
        "Ha-ha!", //baldi evil, 16
    };

    private AudioSource audioSource;
    private AudioSource mainMus;
    private CharacterController player;
    private GC_Finale gc_finale;
    public Sprite[] dialogue01Images;
    public Sprite[] dialogue11Images;
    public Sprite[] dialogueNULLImages;
    public Animator anim_left;
    public Animator anim_right;
    public TextMeshProUGUI text;
    public Image dialogueImage;
    private Sprite dialogueImage_null;
    public GameObject BLACK_BG;
    public GameObject efx_dlg5_joe;
    public GameObject efx_dlg6_trigger;
    public AudioClip sfx_dlg4_eerie;
    public AudioClip sfx_dlg5_ambient;
    private GameObject efx_dlg5_player;
    public AudioClip sfx_dlg6_ambient;
    public Follow mnb_dlg10_follow01;
    public Follow mnb_dlg10_follow02;
    public GameObject efx_dlg99_2_baldi;

    void Start()
    {
        gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        dialogueImage_null = dialogueImage.sprite;
        efx_dlg5_player = GameObject.FindGameObjectWithTag("Player");
        player = efx_dlg5_player.GetComponent<CharacterController>();

        if (SceneManager.GetActiveScene().name == "Finale")
        {
            gc_finale = GameObject.FindGameObjectWithTag("GameController").GetComponent<GC_Finale>();
        }
    }

    void Update()
    {
        if (mainMus == null)
        {
            mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();
        }

        if (Input.GetMouseButtonDown(0) | Input.GetMouseButtonDown(1))
        {
            if (slideCount >= 0)
            {
                slideCount--;

                switch (dialogueType)
                {
                    case -1:
                        ChangeTextAndImageAndChar(introDialogue, dialogueNULLImages, -1);
                        break;
                    case 0:
                        ChangeTextAndImageAndChar(dialogue01, dialogue01Images, 1);
                        break;
                    case 1:
                        ChangeTextAndImageAndChar(dialogue02, dialogueNULLImages, 1);
                        break;
                    case 2:
                        ChangeTextAndImageAndChar(dialogue03, dialogueNULLImages, 1);
                        break;
                    case 3:
                        if (slideCount != 0)
                        {
                            ChangeTextAndImageAndChar(dialogue04, dialogueNULLImages, 1);
                        }

                        else
                        {
                            ChangeTextAndImageAndChar(dialogue04, dialogueNULLImages, -1);
                        }

                        if (slideCount == 1)
                        {
                            audioSource.PlayOneShot(sfx_dlg4_eerie);
                        }
                        break;
                    case 4:
                        if (slideCount == 9 | slideCount == 7 | slideCount == 5 | slideCount == 3 | slideCount == 0)
                        {
                            ChangeTextAndImageAndChar(dialogue05, dialogueNULLImages, 1);
                            anim_right.Play("Player");
                        }

                        else if (slideCount == 6 | slideCount == 4 | slideCount == 2 | slideCount == 1)
                        {
                            ChangeTextAndImageAndChar(dialogue05, dialogueNULLImages, 0);
                            anim_left.Play("Joe");
                        }

                        else if (slideCount == 8)
                        {
                            ChangeTextAndImageAndChar(dialogue05, dialogueNULLImages, -1);
                        }
                        break;
                    case 5:
                        ChangeTextAndImageAndChar(dialogue06, dialogueNULLImages, 1);
                        break;
                    case 6:
                        if (slideCount == 6 | slideCount == 4 | slideCount == 2 | slideCount == 1)
                        {
                            ChangeTextAndImageAndChar(dialogue07, dialogueNULLImages, -1);
                        }

                        else if (slideCount == 5 | slideCount == 3 | slideCount == 0)
                        {
                            ChangeTextAndImageAndChar(dialogue07, dialogueNULLImages, 1);
                            anim_right.Play("Player");
                        }
                        break;
                    case 7:
                        ChangeTextAndImageAndChar(dialogue08, dialogueNULLImages, 1);
                        break;
                    case 8:
                        ChangeTextAndImageAndChar(dialogue09, dialogueNULLImages, 1);
                        break;
                    case 9:
                        if (slideCount == 9 | slideCount == 6 | slideCount == 3 | slideCount == 1)
                        {
                            ChangeTextAndImageAndChar(dialogue10, dialogueNULLImages, 1);
                            anim_right.Play("Player");
                        }

                        else if (slideCount == 8 | slideCount == 7)
                        {
                            ChangeTextAndImageAndChar(dialogue10, dialogueNULLImages, 0);
                            anim_left.Play("BAL_Happy");
                        }

                        else if (slideCount == 0)
                        {
                            ChangeTextAndImageAndChar(dialogue10, dialogueNULLImages, 0);
                            anim_left.Play("BAL_Sad");
                        }

                        else if (slideCount == 5 | slideCount == 4 | slideCount == 2)
                        {
                            ChangeTextAndImageAndChar(dialogue10, dialogueNULLImages, 0);
                            anim_left.Play("Pri_talk");
                        }
                        break;
                    case 10:
                        if (slideCount == 5 | slideCount == 3)
                        {
                            ChangeTextAndImageAndChar(dialogue11, dialogue11Images, 1);
                            anim_right.Play("Player");
                        }

                        else if (slideCount == 4)
                        {
                            ChangeTextAndImageAndChar(dialogue11, dialogue11Images, 0);
                            anim_left.Play("BAL_Angry");
                        }
                        
                        else if (slideCount == 2)
                        {
                            ChangeTextAndImageAndChar(dialogue11, dialogue11Images, 0);
                            anim_left.Play("BAL_Mad");
                        }

                        else if (slideCount == 1)
                        {
                            ChangeTextAndImageAndChar(dialogue11, dialogue11Images, 0);
                            anim_left.Play("Joe");
                        }

                        else if (slideCount == 0)
                        {
                            ChangeTextAndImageAndChar(dialogue11, dialogue11Images, 0);
                            anim_left.Play("Pri_talk");
                        }
                        break;
                    case 11:
                        if (slideCount == 1)
                        {
                            ChangeTextAndImageAndChar(dialogue12, dialogueNULLImages, 0);
                            anim_left.Play("Pri_talk");
                        }

                        else
                        {
                            ChangeTextAndImageAndChar(dialogue12, dialogueNULLImages, 0);
                            anim_left.Play("BAL_Sad");
                        }
                        break;
                    case 99:
                        if (slideCount == 1)
                        {
                            ChangeTextAndImageAndChar(dialogue99_0, dialogueNULLImages, 1);
                            anim_right.Play("Player");
                        }

                        else
                        {
                            ChangeTextAndImageAndChar(dialogue99_0, dialogueNULLImages, 0);
                            anim_left.Play("BAL_Sad");
                        }
                        break;
                    case 100:
                        if (slideCount == 9 | slideCount == 0)
                        {
                            ChangeTextAndImageAndChar(dialogue99_1, dialogueNULLImages, 1);
                            anim_right.Play("Player");
                        }

                        else if (slideCount == 8 | slideCount == 7 | slideCount == 6 | slideCount == 5)
                        {
                            ChangeTextAndImageAndChar(dialogue99_1, dialogueNULLImages, 0);
                            anim_left.Play("Joe");
                        }

                        else if (slideCount == 4 | slideCount == 3 | slideCount == 2 | slideCount == 1)
                        {
                            ChangeTextAndImageAndChar(dialogue99_1, dialogueNULLImages, 0);
                            anim_left.Play("BAL_Sad");
                        }
                        break;
                    case 101:
                        if (slideCount == 10 | slideCount == 9 | slideCount == 8 | slideCount == 7) //joe mad
                        {
                            ChangeTextAndImageAndChar(dialogue99_2, dialogueNULLImages, 0);
                            anim_left.Play("Joe_Angry");
                        }

                        else if (slideCount == 16 | slideCount == 6) //baldi evil
                        {
                            ChangeTextAndImageAndChar(dialogue99_2, dialogueNULLImages, 0);
                            anim_left.Play("BAL_HappyEvil");
                        }

                        else if (slideCount == 15 | slideCount == 14 | slideCount == 11 | slideCount == 5 | slideCount == 1) //player
                        {
                            ChangeTextAndImageAndChar(dialogue99_2, dialogueNULLImages, 1);
                            anim_right.Play("Player");
                        }

                        else if (slideCount == 13 | slideCount == 12) //joe happy
                        {
                            ChangeTextAndImageAndChar(dialogue99_2, dialogueNULLImages, 0);
                            anim_left.Play("Joe");
                        }

                        else if (slideCount == 4 | slideCount == 3 | slideCount == 2 | slideCount == 0) //baldi sad
                        {
                            ChangeTextAndImageAndChar(dialogue99_2, dialogueNULLImages, 0);
                            anim_left.Play("BAL_Sad");
                        }
                        break;
                }

                if (slideCount < 0)
                {
                    dialogue = false;
                    dialogueImage.sprite = dialogueImage_null;
                    gameObject.SetActive(false);
                    player.GetComponent<Player>().stamina.value = 100f;

                    if (SceneManager.GetActiveScene().name == "Finale")
                    {
                        gc_finale.hud.SetActive(true);
                    }

                    switch (dialogueType)
                    {
                        case 6:
                            SceneManager.LoadScene("Chapter2");
                            break;
                        case 10:
                            GameObject.FindGameObjectWithTag("GameController").GetComponent<GC_Tragic>().StartCoroutine("ContinueChaos");
                            break;
                        case 99:
                            gc_finale.chapter.GetComponent<TextMeshProUGUI>().text = "Finale";
                            gc_finale.chapter.GetComponent<Animator>().Play("NewChapter");
                            break;
                        case 100:
                            gc_finale.StartCoroutine("StartBossIntro");
                            break;
                    }
                }
            }
        }

        if (dialogue)
        {
            BLACK_BG.SetActive(true);
            Time.timeScale = 0f;
        }

        else
        {
            BLACK_BG.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void StartDialoge(int DialogueType)
    {
        dialogue = true;
        dialogueType = DialogueType;
        gameObject.SetActive(true);

        if (SceneManager.GetActiveScene().name == "Finale")
        {
            gc_finale.hud.SetActive(false);
        }

        switch (dialogueType)
        {
            case -1:
                DeactiveAll();
                text.text = "One day, you come to Baldi's school.";
                slideCount = introDialogue.Length;
                break;
            case 0:
                ActivateRight();
                anim_right.Play("Player");
                text.text = "What the hell happened to this place?";
                slideCount = dialogue01.Length;
                break;
            case 1:
                ActivateRight();
                anim_right.Play("Player");
                text.text = "What?! The door is unlocked but there is a wooden wall blocking my way!";
                slideCount = dialogue02.Length;
                break;
            case 2:
                ActivateRight();
                anim_right.Play("Player");
                text.text = "WHAT THE HELL?!";
                slideCount = dialogue03.Length;
                break;
            case 3:
                ActivateRight();
                anim_right.Play("Player");
                text.text = "Dead end.";
                slideCount = dialogue04.Length;
                break;
            case 4:
                DeactiveAll();
                text.text = "Ha ha ha!";
                slideCount = dialogue05.Length;
                efx_dlg5_joe.SetActive(true);
                efx_dlg6_trigger.SetActive(true);
                break;
            case 5:
                ActivateRight();
                anim_right.Play("Player");
                text.text = "I think I found Baldi's kitchen!";
                slideCount = dialogue06.Length;
                player.enabled = false;
                efx_dlg5_player.transform.position = new Vector3(-15f, -110f, 75f);
                efx_dlg5_player.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                player.enabled = true;
                mainMus.clip = sfx_dlg5_ambient;
                mainMus.volume = 0.5f;
                mainMus.Play();
                break;
            case 6:
                ActivateRight();
                anim_right.Play("Player");
                text.text = "Woah! What is this...";
                slideCount = dialogue07.Length;
                player.enabled = false;
                efx_dlg5_player.transform.position = new Vector3(-45f, -80f, 45f);
                efx_dlg5_player.transform.rotation = Quaternion.identity;
                player.enabled = true;
                mainMus.clip = sfx_dlg6_ambient;
                mainMus.Play();
                break;
            case 7:
                ActivateRight();
                anim_right.Play("Player");
                text.text = "This place is creepy.";
                slideCount = dialogue08.Length;
                break;
            case 8:
                ActivateRight();
                anim_right.Play("Player");
                text.text = "This is weird...";
                slideCount = dialogue09.Length;
                break;
            case 9:
                ActivateRight();
                anim_right.Play("Player");
                text.text = "Baldi?!";
                slideCount = dialogue10.Length;
                mnb_dlg10_follow01.follow = true;
                mnb_dlg10_follow02.follow = true;
                break;
            case 10:
                ActivateLeft();
                anim_left.Play("Joe");
                text.text = "Well well well!";
                slideCount = dialogue11.Length;
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GC_Tragic>().StartChaos();
                break;
            case 11:
                ActivateLeft();
                anim_left.Play("Pri_talk");
                text.text = "I'm too tired to run...";
                slideCount = dialogue12.Length;
                mnb_dlg10_follow02.follow = false;
                break;
            case 99:
                ActivateRight();
                anim_right.Play("Player");
                text.text = "What is this place...?";
                slideCount = dialogue99_0.Length;
                break;
            case 100:
                {
                    ActivateLeft();
                    anim_left.Play("Joe");
                    text.text = "Well, I guess you idiots somehow found me!";
                    slideCount = dialogue99_1.Length;

                    AudioSource mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();

                    mainMus.clip = GameObject.FindGameObjectWithTag("GameController").GetComponent<GC_Finale>().mus_bossfinale2;
                    mainMus.volume = 0.1f;
                    mainMus.Play();
                    break;
                }
            case 101:
                ActivateLeft();
                anim_left.Play("Joe_Angry");
                text.text = "UGH!!!";
                slideCount = dialogue99_2.Length;
                efx_dlg99_2_baldi.SetActive(true);
                break;
        }
    }

    void ChangeTextAndImageAndChar(string[] dialogueNum, Sprite[] dialogueImageNum, int side)
    {
        if (slideCount >= 0)
        {
            text.text = dialogueNum[slideCount];
            dialogueImage.sprite = dialogueImageNum[slideCount];
        }

        switch (side)
        {
            case -1:
                DeactiveAll();
                break;
            case 0:
                ActivateLeft();
                break;
            case 1:
                ActivateRight();
                break;
            case 4:
                ActivateBoth();
                break;
        }
    }

    void ActivateLeft()
    {
        anim_left.gameObject.SetActive(true);
        anim_right.gameObject.SetActive(false);
    }

    void ActivateRight()
    {
        anim_left.gameObject.SetActive(false);
        anim_right.gameObject.SetActive(true);
    }

    void ActivateBoth()
    {
        anim_left.gameObject.SetActive(true);
        anim_right.gameObject.SetActive(true);
    }

    void DeactiveAll()
    {
        anim_left.gameObject.SetActive(false);
        anim_right.gameObject.SetActive(false);
    }
}
