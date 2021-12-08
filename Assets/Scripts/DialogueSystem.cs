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
    private string[] dialogue02 = {"Let me get a closer look..."};
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
    private string[] dialogue06 = new string[3]
    {
        "I need to find some food, though... I'm starving...",
        "Well, at least I won't see Joe in a couple of days.",
        "But what is that noise??"
    };
    private string[] dialogue99_0 = new string[3]
    {
        "I think so...",
        "So do we just try to find him?",
        "I think this is where Joe lives."
    };
    private string[] dialogue99_1 = new string[6]
    {
        "Uh oh...", //0
        "<color=red>EVERTHING GOES CRAZY!", //1
        "When it's a finale...", //2
        "This is the finale...", //3
        "Because...", //4
        "Why are your eyes blue?" //5
    };
    private AudioSource audioSource;
    private AudioSource mainMus;
    private GameObject hud;
    public Sprite[] dialogue01Images;
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

    private void Start()
    {
        gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        dialogueImage_null = dialogueImage.sprite;
        
        if (SceneManager.GetActiveScene().name == "Finale")
        {
            hud = GameObject.Find("Hud");
        }
    }

    private void Update()
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

                if (dialogueType == -1)
                {
                    ChangeTextAndImageAndChar(introDialogue, dialogueNULLImages, -1);
                }
                
                else if (dialogueType == 0)
                {
                    ChangeTextAndImageAndChar(dialogue01, dialogue01Images, 1);
                }

                else if (dialogueType == 1)
                {
                    ChangeTextAndImageAndChar(dialogue02, dialogueNULLImages, 1);
                }

                else if (dialogueType == 2)
                {
                    ChangeTextAndImageAndChar(dialogue03, dialogueNULLImages, 1);
                }

                else if (dialogueType == 3)
                {
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
                }

                else if (dialogueType == 4)
                {
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
                }

                else if (dialogueType == 5)
                {
                    ChangeTextAndImageAndChar(dialogue06, dialogueNULLImages, 1);
                }

                else if (dialogueType == 99)
                {
                    if (slideCount == 2)
                    {
                        ChangeTextAndImageAndChar(dialogue99_0, dialogueNULLImages, 0);
                        anim_left.Play("Pri_talk");
                    }

                    else if (slideCount == 1)
                    {
                        ChangeTextAndImageAndChar(dialogue99_0, dialogueNULLImages, 1);
                        anim_right.Play("Player");
                    }

                    else if (slideCount == 0)
                    {
                        ChangeTextAndImageAndChar(dialogue99_0, dialogueNULLImages, 0);
                        anim_left.Play("BAL_Sad");
                    }
                }

                else if (dialogueType == 100)
                {
                    if (slideCount == 1 | slideCount == 2 | slideCount == 3 | slideCount == 4 | slideCount == 6)
                    {
                        ChangeTextAndImageAndChar(dialogue99_1, dialogueNULLImages, 0);
                        anim_left.Play("Joe");
                    }

                    else if (slideCount == 5)
                    {
                        ChangeTextAndImageAndChar(dialogue99_1, dialogueNULLImages, 1);
                        anim_right.Play("Player");
                    }

                    else if (slideCount == 0)
                    {
                        ChangeTextAndImageAndChar(dialogue99_1, dialogueNULLImages, 0);
                        anim_left.Play("BAL_Sad");
                    }
                }

                if (slideCount < 0)
                {
                    dialogue = false;
                    dialogueImage.sprite = dialogueImage_null;
                    gameObject.SetActive(false);

                    if (SceneManager.GetActiveScene().name == "Finale")
                    {
                        hud.SetActive(true);
                    }

                    if (dialogueType == 100)
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<GC_Finale>().StartCoroutine("StartBossIntro");
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
            hud.SetActive(false);
        }

        if (dialogueType == -1)
        {
            DeactiveAll();
            text.text = "One day, you come to Baldi's school.";
            slideCount = introDialogue.Length;
        }
        
        else if (dialogueType == 0)
        {
            ActivateRight();
            anim_right.Play("Player");
            text.text = "What the hell happened to this place?";
            slideCount = dialogue01.Length;
        }

        else if (dialogueType == 1)
        {
            ActivateRight();
            anim_right.Play("Player");
            text.text = "What?! The door is unlocked but there is a wooden wall blocking my way!";
            slideCount = dialogue02.Length;
        }

        else if (dialogueType == 2)
        {
            ActivateRight();
            anim_right.Play("Player");
            text.text = "WHAT THE HELL?!";
            slideCount = dialogue03.Length;
        }

        else if (dialogueType == 3)
        {
            ActivateRight();
            anim_right.Play("Player");
            text.text = "Dead end.";
            slideCount = dialogue04.Length;
        }

        else if (dialogueType == 4)
        {
            DeactiveAll();
            text.text = "Ha ha ha!";
            slideCount = dialogue05.Length;
            efx_dlg5_joe.SetActive(true);
            efx_dlg6_trigger.SetActive(true);
        }

        else if (dialogueType == 5)
        {
            ActivateRight();
            anim_right.Play("Player");
            text.text = "I think I found Baldi's kitchen!";
            slideCount = dialogue06.Length;
            mainMus.clip = sfx_dlg5_ambient;
            mainMus.volume = 0.5f;
            mainMus.Play();
        }

        else if (dialogueType == 99)
        {
            ActivateRight();
            anim_right.Play("Player");
            text.text = "What is this place...?";
            slideCount = dialogue99_0.Length;
        }

        else if (dialogueType == 100)
        {
            ActivateLeft();
            anim_left.Play("Joe");
            text.text = "Well, I guess you idiots somehow found me!";
            slideCount = dialogue99_1.Length;

            AudioSource mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();

            mainMus.clip = GameObject.FindGameObjectWithTag("GameController").GetComponent<GC_Finale>().mus_bossfinale2;
            mainMus.volume = 0.1f;
            mainMus.Play();
        }
    }

    private void ChangeTextAndImageAndChar(string[] dialogueNum, Sprite[] dialogueImageNum, int side)
    {
        if (slideCount >= 0)
        {
            text.text = dialogueNum[slideCount];
            dialogueImage.sprite = dialogueImageNum[slideCount];
        }

        if (side == -1)
        {
            DeactiveAll();
        }

        else if (side == 0)
        {
            ActivateLeft();
        }

        else if (side == 1)
        {
            ActivateRight();
        }

        else if (side == 4)
        {
            ActivateBoth();
        }
    }

    private void ActivateLeft()
    {
        anim_left.gameObject.SetActive(true);
        anim_right.gameObject.SetActive(false);
    }

    private void ActivateRight()
    {
        anim_left.gameObject.SetActive(false);
        anim_right.gameObject.SetActive(true);
    }

    private void ActivateBoth()
    {
        anim_left.gameObject.SetActive(true);
        anim_right.gameObject.SetActive(true);
    }

    private void DeactiveAll()
    {
        anim_left.gameObject.SetActive(false);
        anim_right.gameObject.SetActive(false);
    }
}
