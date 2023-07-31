using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    protected int slideCount;
    protected int remainingSlides;
    protected int dialogueType;
    public bool dialogue;
    protected CharacterController player;
    private string[] currentDialogue;
    private Sprite[] currentImages;
    public Sprite[] dialogue01Images;
    public Sprite[] dialogue11Images;
    public Sprite[] dialogueNULLImages;
    public Animator anim_left;
    public Animator anim_right;
    public TextMeshProUGUI text;
    public Image dialogueImage;
    private Sprite dialogueImage_null;
    public GameObject BLACK_BG;

    protected enum CharSide
    {
        Left = 0,
        Right = 1,
        Both = 4,
        None = -1
    }

    void Start()
    {
        gameObject.SetActive(false);
        dialogueImage_null = dialogueImage.sprite;
        player = FindObjectOfType<BasePlayer>().GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (remainingSlides < slideCount)
            {
                remainingSlides++;
                NextSlide();
            }

            else
            {
                dialogue = false;
                remainingSlides = 0;
                dialogueImage.sprite = dialogueImage_null;
                gameObject.SetActive(false);
                FindObjectOfType<StaminaSlider>(true).GetComponent<Slider>().value = 100f;
                OnDialogueEnd();
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

    protected virtual void InitDialogue() { }
    protected virtual void NextSlide() { }
    protected virtual void OnDialogueEnd() { }

    public virtual void StartDialogue(int DialogueType)
    {
        dialogue = true;
        dialogueType = DialogueType;
        InitDialogue();
        slideCount = currentDialogue.Length - 1;
        gameObject.SetActive(true);
        NextSlide();
    }

    protected void SetDialogue(string[] text, Sprite[] images = null)
    {
        currentDialogue = text;
        currentImages = images;
    }

    [Obsolete("Use ShowDialogue")]
    protected void ChangeTextAndImageAndChar(string[] dialogueNum, Sprite[] dialogueImageNum, int side, string left = "Joe", string right = "Player")
    {
        ShowDialogue((CharSide)side, left, right);
    }

    protected void ShowDialogue(CharSide side = CharSide.Right, string left = "Joe", string right = "Player")
    {
        if (remainingSlides <= slideCount)
        {
            text.text = currentDialogue[remainingSlides];

            if (currentImages != null)
            {
                dialogueImage.sprite = currentImages[remainingSlides];
            }
        }

        switch (side)
        {
            case CharSide.None:
                anim_left.gameObject.SetActive(false);
                anim_right.gameObject.SetActive(false);
                break;
            case CharSide.Left:
                anim_left.gameObject.SetActive(true);
                anim_right.gameObject.SetActive(false);
                anim_left.Play(left);
                break;
            case CharSide.Right:
                anim_left.gameObject.SetActive(false);
                anim_right.gameObject.SetActive(true);
                anim_right.Play(right);
                break;
            case CharSide.Both:
                anim_left.gameObject.SetActive(true);
                anim_right.gameObject.SetActive(true);
                anim_left.Play(left);
                anim_right.Play(right);
                break;
        }
    }
}
