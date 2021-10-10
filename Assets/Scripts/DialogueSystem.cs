using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    private int slideCount;
    private int dialogueType;
    public bool dialogue;
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
        "<i>Wait a minute! While's he's thinking, I could escape! This is perfect!", //0
        "Let me think...", //1
        "Hmm...", //2
        "So what are you gonna do to me?", //3
        "<color=red>Oh yes!", //4
        "Oh no...", //5
        "Well yes, of cource, idiot!", //6
        "Is that... Joe?", //7
        "Ready for a deadly chainsaw?", //8
        "Hold on, who--" //9
    };
    private string[] dialogue99_0 = new string[3]
    {
        "I think so...",
        "So do we just try to find him?",
        "I think this is where Joe lives."
    };
    private AudioSource audioSource;
    public Sprite[] dialogue01Images;
    public Sprite[] dialogueNULLImages;
    public Animator anim_left;
    public Animator anim_right;
    public TextMeshProUGUI text;
    public Image dialogueImage;
    private Sprite dialogueImage_null;
    public GameObject BLACK_BG;
    public GameObject efx_dlg5_joe;
    public AudioClip sfx_dlg4_eerie;

    void Start()
    {
        gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        dialogueImage_null = dialogueImage.sprite;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) | Input.GetMouseButtonDown(1))
        {
            if (slideCount >= 0)
            {
                slideCount--;

                if (dialogueType == 0)
                {
                    ChangeTextAndImageAndChar(dialogue01, dialogue01Images, 1, false);
                }

                else if (dialogueType == 1)
                {
                    ChangeTextAndImageAndChar(dialogue02, dialogueNULLImages, 1, false);
                }

                else if (dialogueType == 2)
                {
                    ChangeTextAndImageAndChar(dialogue03, dialogueNULLImages, 1, false);
                }

                else if (dialogueType == 3)
                {
                    if (slideCount != 0)
                    {
                        ChangeTextAndImageAndChar(dialogue04, dialogueNULLImages, 1, false);
                    }

                    else
                    {
                        ChangeTextAndImageAndChar(dialogue04, dialogueNULLImages, -1, false);
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
                        ChangeTextAndImageAndChar(dialogue05, dialogueNULLImages, 1, false);
                        anim_right.Play("Player");
                    }

                    else if (slideCount == 6 | slideCount == 4 | slideCount == 2 | slideCount == 1)
                    {
                        ChangeTextAndImageAndChar(dialogue05, dialogueNULLImages, 0, false);
                        anim_left.Play("Joe");
                    }

                    else if (slideCount == 8)
                    {
                        ChangeTextAndImageAndChar(dialogue05, dialogueNULLImages, -1, false);
                    }
                }

                else if (dialogueType == 99)
                {
                    if (slideCount == 2)
                    {
                        ChangeTextAndImageAndChar(dialogue99_0, dialogueNULLImages, 0, false);
                        anim_left.Play("Pri_talk");
                    }

                    else if (slideCount == 1)
                    {
                        ChangeTextAndImageAndChar(dialogue99_0, dialogueNULLImages, 1, false);
                        anim_right.Play("Player");
                    }

                    else if (slideCount == 0)
                    {
                        ChangeTextAndImageAndChar(dialogue99_0, dialogueNULLImages, 0, false);
                        anim_left.Play("BAL_Sad");
                    }
                }

                if (slideCount < 0)
                {
                    dialogue = false;
                    dialogueImage.sprite = dialogueImage_null;
                    gameObject.SetActive(false);
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

    public void StartDialoge(int DialogeType)
    {
        dialogue = true;
        dialogueType = DialogeType;
        gameObject.SetActive(true);

        if (dialogueType == 0)
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
        }

        else if (dialogueType == 99)
        {
            ActivateRight();
            anim_right.Play("Player");
            text.text = "What is this place...?";
            slideCount = dialogue99_0.Length;
        }
    }

    void ChangeTextAndImageAndChar(string[] dialogueNum, Sprite[] dialogueImageNum, int side, bool loadText)
    {
        if (slideCount >= 0)
        {
            text.text = dialogueNum[slideCount];
            dialogueImage.sprite = dialogueImageNum[slideCount];
        }

        else
        {
            if (loadText)
            {
                text.text = "LOADING";
            }
        }

        if (side == 0)
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

        else if (side == -1)
        {
            DeactiveAll();
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