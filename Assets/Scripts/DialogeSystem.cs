using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogeSystem : MonoBehaviour
{
    private int slideCount;
    private int dialogeType;
    public bool dialoge;
    private string[] dialoge01 = new string[2]
    {
        "But I think I need to find the key to the door first...",
        "Oh, wait! There's a locked door there!"
    };
    private string[] dialoge02 = {"Let me get a closer look..."};
    private string[] dialoge03 = new string[2]
    {
        "I think I'm in some kind of vent...",
        "I've gotta get the hell outta here!"
    };
    private string[] dialoge04 = new string[5]
    {
        "Off you go into the secret, unknown place.",
        "Wait a minute, what's that sound?!",
        "Alright, let's try going there.",
        "Wait, there's an opening here; how did I not notice it?",
        "Let's see if there's a way to get outta here."
    };
    private string[] dialoge05 = new string[10]
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
    private string[] dialoge99_0 = new string[3]
    {
        "I think so...",
        "So do we just try to find him?",
        "I think this is where Joe lives."
    };
    private AudioSource audioSource;
    public Sprite[] dialoge01Images;
    public Sprite[] dialogeNULLImages;
    public Animator anim_left;
    public Animator anim_right;
    public TextMeshProUGUI text;
    public Image dialogeImage;
    private Sprite dialogeImage_null;
    public GameObject BLACK_BG;
    public GameObject efx_dlg5_barrier;
    public GameObject efx_dlg5_joe;
    public AudioClip sfx_dlg4_eerie;

    void Start()
    {
        gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        dialogeImage_null = dialogeImage.sprite;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) | Input.GetMouseButtonDown(1))
        {
            if (slideCount >= 0)
            {
                slideCount--;

                if (dialogeType == 0)
                {
                    ChangeTextAndImageAndChar(dialoge01, dialoge01Images, 1, false);
                }

                else if (dialogeType == 1)
                {
                    ChangeTextAndImageAndChar(dialoge02, dialogeNULLImages, 1, false);
                }

                else if (dialogeType == 2)
                {
                    ChangeTextAndImageAndChar(dialoge03, dialogeNULLImages, 1, false);
                }

                else if (dialogeType == 3)
                {
                    if (slideCount != 0)
                    {
                        ChangeTextAndImageAndChar(dialoge04, dialogeNULLImages, 1, false);
                    }

                    else
                    {
                        ChangeTextAndImageAndChar(dialoge04, dialogeNULLImages, -1, false);
                    }

                    if (slideCount == 1)
                    {
                        audioSource.PlayOneShot(sfx_dlg4_eerie);
                    }
                }

                else if (dialogeType == 4)
                {
                    if (slideCount == 9 | slideCount == 7 | slideCount == 5 | slideCount == 3 | slideCount == 0)
                    {
                        ChangeTextAndImageAndChar(dialoge05, dialogeNULLImages, 1, false);
                        anim_right.Play("Player");
                    }

                    else if (slideCount == 6 | slideCount == 4 | slideCount == 2 | slideCount == 1)
                    {
                        ChangeTextAndImageAndChar(dialoge05, dialogeNULLImages, 0, false);
                        anim_left.Play("Joe");
                    }

                    else if (slideCount == 8)
                    {
                        ChangeTextAndImageAndChar(dialoge05, dialogeNULLImages, -1, false);
                    }
                }

                else if (dialogeType == 99)
                {
                    if (slideCount == 2)
                    {
                        ChangeTextAndImageAndChar(dialoge99_0, dialogeNULLImages, 0, false);
                        anim_left.Play("Pri_talk");
                    }

                    else if (slideCount == 1)
                    {
                        ChangeTextAndImageAndChar(dialoge99_0, dialogeNULLImages, 1, false);
                        anim_right.Play("Player");
                    }

                    else if (slideCount == 0)
                    {
                        ChangeTextAndImageAndChar(dialoge99_0, dialogeNULLImages, 0, false);
                        anim_left.Play("BAL_Sad");
                    }
                }

                if (slideCount < 0)
                {
                    dialoge = false;
                    dialogeImage.sprite = dialogeImage_null;
                    gameObject.SetActive(false);
                }
            }
        }

        if (dialoge)
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
        dialoge = true;
        dialogeType = DialogeType;
        gameObject.SetActive(true);

        if (dialogeType == 0)
        {
            ActivateRight();
            anim_right.Play("Player");
            text.text = "What the hell happened to this place?";
            slideCount = dialoge01.Length;
        }

        else if (dialogeType == 1)
        {
            ActivateRight();
            anim_right.Play("Player");
            text.text = "What?! The door is unlocked but there is a wooden wall blocking my way!";
            slideCount = dialoge02.Length;
        }

        else if (dialogeType == 2)
        {
            ActivateRight();
            anim_right.Play("Player");
            text.text = "WHAT THE HELL?!";
            slideCount = dialoge03.Length;
        }

        else if (dialogeType == 3)
        {
            ActivateRight();
            anim_right.Play("Player");
            text.text = "Dead end.";
            slideCount = dialoge04.Length;
        }

        else if (dialogeType == 4)
        {
            DeactiveAll();
            text.text = "Ha ha ha!";
            slideCount = dialoge05.Length;
            efx_dlg5_barrier.SetActive(true);
            efx_dlg5_joe.SetActive(false);
        }

        else if (dialogeType == 99)
        {
            ActivateRight();
            anim_right.Play("Player");
            text.text = "What is this place...?";
            slideCount = dialoge99_0.Length;
        }
    }

    void ChangeTextAndImageAndChar(string[] dialogeNum, Sprite[] dialogeImageNum, int side, bool loadText)
    {
        if (slideCount >= 0)
        {
            text.text = dialogeNum[slideCount];
            dialogeImage.sprite = dialogeImageNum[slideCount];
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