using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    protected int slideCount;
    protected int dialogueType;
    public bool dialogue;
    protected AudioSource audioSource;
    protected AudioSource mainMus;
    protected CharacterController player;
    public Sprite[] dialogue01Images;
    public Sprite[] dialogue11Images;
    public Sprite[] dialogueNULLImages;
    public Animator anim_left;
    public Animator anim_right;
    public TextMeshProUGUI text;
    public Image dialogueImage;
    private Sprite dialogueImage_null;
    public GameObject BLACK_BG;

    public virtual void Start()
    {
        gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        dialogueImage_null = dialogueImage.sprite;
        player = FindObjectOfType<Player>().GetComponent<CharacterController>();
    }

    public virtual void Update()
    {
        if (mainMus == null)
        {
            mainMus = GameControllerScript.GetMainMus();
        }

        if (Input.GetMouseButtonDown(0) | Input.GetMouseButtonDown(1))
        {
            if (slideCount >= 0)
            {
                slideCount--;
                NextSlide();

                if (slideCount < 0)
                {
                    dialogue = false;
                    dialogueImage.sprite = dialogueImage_null;
                    gameObject.SetActive(false);
                    player.GetComponent<Player>().stamina.value = 100f;
                    OnDialogueEnd();
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

    public virtual void StartDialogue(int DialogueType)
    {
        dialogue = true;
        dialogueType = DialogueType;
        gameObject.SetActive(true);
    }

    public virtual void NextSlide() { }
    public virtual void OnDialogueEnd() { }

    protected void ChangeTextAndImageAndChar(string[] dialogueNum, Sprite[] dialogueImageNum, int side, string left = "Joe", string right = "Player")
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
                ActivateLeft(left);
                break;
            case 1:
                ActivateRight(right);
                break;
            case 4:
                ActivateBoth(left, right);
                break;
        }
    }

    protected void ActivateLeft(string anim = "Joe")
    {
        anim_left.gameObject.SetActive(true);
        anim_right.gameObject.SetActive(false);
        anim_left.Play(anim);
    }

    protected void ActivateRight(string anim = "Player")
    {
        anim_left.gameObject.SetActive(false);
        anim_right.gameObject.SetActive(true);
        anim_right.Play(anim);
    }

    protected void ActivateBoth(string anim = "Joe", string anim2 = "Player")
    {
        anim_left.gameObject.SetActive(true);
        anim_right.gameObject.SetActive(true);
        anim_left.Play(anim);
        anim_right.Play(anim2);
    }

    protected void DeactiveAll()
    {
        anim_left.gameObject.SetActive(false);
        anim_right.gameObject.SetActive(false);
    }
}
