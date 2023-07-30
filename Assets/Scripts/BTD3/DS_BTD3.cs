using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using BTD3Framework;

public class DS_BTD3 : DialogueSystem
{
    string[] introDialogue =
    {
        "One day, you come to Baldi's school.",
        "But then, you realize that Baldi is not there.",
        "You search for him, and no luck...",
        "So you ask Principal where he lives.",
        "Principal told you his address,",
        "...and you went to his house."
    };
    string[] dialogue01 =
    {
        "What the hell happened to this place?",
        "Oh, wait! There's a locked door there!",
        "But I think I need to find the key to the door first..."
    };
    string[] dialogue02 =
    {
        "What?! The door is unlocked but there is a wooden wall blocking my way!",
        "Let me get a closer look..."
    };
    string[] dialogue03 =
    {
        "WHAT THE HELL?!",
        "I've gotta get the hell outta here!",
        "I think I'm in some kind of vent..."
    };
    string[] dialogue04 =
    {
        "Dead end.",
        "Let's see if there's a way to get outta here.",
        "Wait, there's an opening here; how did I not notice it?",
        "Alright, let's go in.",
    };
    string[] dialogue05 =
    {
        "Ha ha ha!", //0
        "Hold on, who--", //1, player
        "Ready for a deadly chainsaw?", //2
        "Is that... Joe?", //3, player
        "Why yes, of course, idiot!", //4, joe
        "Oh no...", //5, player
        "<color=red>Oh yes!", //6, joe
        "So what are you gonna do to me?", //7, player
        "Hmm...", //8, joe
        "Let me think... I gotta make up a really huge plan...", //9, joe
        "<i>Hmm, it's gonna take him a long time, huh? Then, let's escape!" //10, player
    };
    string[] dialogue06 =
    {
        "I think I found Baldi's kitchen!",
        "Well, I won't see Joe for a long time, that's for sure!",
        "I need to find some food, though... I'm starving..."
    };
    string[] dialogue07 =
    {
        "Woah! What is this...", //0, player
        "HELP!!!!!!", //1
        "What?? Is that Baldi?!", //2, player
        "YES, AND I'M KIDNAPPED BY JOE!!!", //3
        "Oh no! How can I save you?!", //4, player
        "TO SAVE ME, YOU MUST GO THROUGH PLANET XEN!", //5
        "BUT BE CAREFUL, THERE ARE DANGEROUS ALIENS THERE!", //6
        "Don't worry, Baldi! I'll save you!" //7, player
    };
    string[] dialogue08 =
    {
        "This place is creepy.",
        "And what was that alien?",
        "I gotta get outta here soon..."
    };
    string[] dialogue09 =
    {
        "This is weird...",
        "Why did Baldi never tell us about this?",
        "And why does he even have this in the first place??",
        "Speaking of Baldi, where is he?"
    };
    string[] dialogue10 =
    {
        "Baldi?!", //0, player
        "Principal?!", //1, player
        "Player!", //2, baldi
        "I'm so glad you made it through Xen!", //3, baldi
        "But wait, Principal, what are you doing here?", //4, player
        "After you told me Baldi was gone...", //5, pri
        "I decided to check it out myself.", //6, pri
        "So what are we gonna do now?", //7, player
        "We have to go further, and escape out of here.", //8, pri
        "Okay. But what if Joe finds us?", //9, player
        "I don't know..." //10, baldi sad
    };
    string[] dialogue11 =
    {
        "Well well well!", //0, joe
        "Oh no... He found us!", //1, player
        "Wait, are you slapping with MY ruler?!", //2, baldi angry
        "He stole it while I was in your brain.", //3, player
        "I'M GONNA KILL YOU FOR THAT!!!", //4, baldi mad
        "Correction: I'M going to kill ALL OF YOU!!!", //5, joe
        "RUN!!!" //6, pri
    };
    string[] dialogue12 =
    {
        "I'm too tired to run...", //pri, 0
        "We can't leave you here, Principal!", //baldi, 1
        "Go on without me! I'll survive!", //pri, 2
        "NOOOOOO!" //baldi and player, 3
    };
    string[] dialogue99_0 = //finale intro
    {
        "What is this place...?", //player, 0
        "I think this is where Joe lives.", //baldi, 1
        "So do we just try to find him?", //player, 2
        "I think so..." //baldi, 3
    };
    string[] dialogue99_1 = //finale bossbattle intro
    {
        "Well, I guess you idiots somehow found me!", //0, joe
        "Why is your face blue?", //1, player
        "Because...", //2, joe
        "This is the finale...", //3, joe
        "When it's a finale...", //4, joe
        "<color=red>EVERTHING GOES CRAZY!", //5, joe
        "Uh oh...", //6, baldi
        "Listen, Player, I can't fight with you...", //7, baldi
        "I must stay back.", //8, baldi
        "I believe in you!", //9, baldi
        "Okay..." //10, player
    };
    string[] dialogue99_2 = //finale outro 1
    {
        "UGH!!!", //joe mad, 0
        "Ha-ha!", //baldi evil, 1
        "It's too early to celebrate!", //player, 2
        "We must escape from his deadly chainsaw!", //player, 3
        "Good luck with that, I set up a bomb here!", //joe happy, 4
        "So you all DIE!!!", //joe happy, 5
        "Wait, but won't you die too?", //player, 6
        "Wait.", //joe mad, 7
        "WAIT.", //joe mad, 8
        "No.", //joe mad, 9
        "No no no NO NO NO!!!!!!", //joe mad, 10
        "HA HA HA!!!", //baldi evil, 11
        "Baldi, we are about to die and you are <i>HAPPY?!</i>", //player, 12
        "You're right.", //baldi sad, 13
        "<i>*sigh*", //baldi sad, 14
        "Wait, what's that noise?", //baldi sad, 15
        "It's coming from the top!", //player, 16
        "Let's check it out!" //baldi sad, 17
    };
    string[] dialogue99_3 = //finale outro 2
    {
        "Hey there!", //playtime, 0
        "Playtime?!", //player, 1
        "Yes, I have come to rescue you!", //playtime, 2
        "Principal told me about the whole thing!", //playime, 3
        "Just in time!", //baldi happy, 4
        "NO!!!", //joe mad, 5
        "Get in, quick, before Joe gets you!" //playtime, 6
    };
    string[] outroDialogue =
    {
        "Ahh!",
        "School sweet school!",
        "It's so amazing that Joe is finally gone!",
        "This was even crazier than going into Baldi's brain!",
        "Imma head back home. It's 12:00 in the morning already!"
    };
    public GameObject efx_dlg5_joe;
    public GameObject efx_dlg6_trigger;
    public AudioClip sfx_dlg5_ambient;
    public AudioClip sfx_dlg6_ambient;
    public Follow mnb_dlg10_follow01;
    public Follow mnb_dlg10_follow02;
    public Material rfx_dlg10_sky;
    public GameObject efx_dlg10_barrier;
    public GC_Finale gc_finale;
    public GameObject efx_dlg99_2_helicopter;
    public GameObject trg_dlg99_2_heli;
    public GameObject trg_dlg99_2_playtime;

    protected override void InitDialogue()
    {
        switch (dialogueType)
        {
            case -1:
                SetDialogue(introDialogue);
                break;
            case 0:
                SetDialogue(dialogue01, dialogue01Images);
                break;
            case 1:
                SetDialogue(dialogue02);
                break;
            case 2:
                SetDialogue(dialogue03);
                break;
            case 3:
                SetDialogue(dialogue04);
                break;
            case 4:
                SetDialogue(dialogue05);
                efx_dlg5_joe.SetActive(true);
                efx_dlg6_trigger.SetActive(true);
                break;
            case 5:
                SetDialogue(dialogue06);
                WorldFunctions.TeleportPlayer(new Vector3(-15f, -110f, 75f), Quaternion.Euler(0f, 180f, 0f));
                MainMus.SetMainMus(sfx_dlg5_ambient, 0.5f);
                break;
            case 6:
                SetDialogue(dialogue07);
                WorldFunctions.TeleportPlayer(new Vector3(-45f, -80f, 45f), Quaternion.identity);
                MainMus.SetMainMus(sfx_dlg6_ambient);
                break;
            case 7:
                SetDialogue(dialogue08);
                break;
            case 8:
                SetDialogue(dialogue09);
                break;
            case 9:
                SetDialogue(dialogue10);
                mnb_dlg10_follow01.follow = true;
                mnb_dlg10_follow02.follow = true;
                efx_dlg10_barrier.SetActive(true);
                RenderSettings.skybox = rfx_dlg10_sky;
                break;
            case 10:
                SetDialogue(dialogue11, dialogue11Images);
                GameObject.FindWithTag("GameController").GetComponent<GC_Tragic>().StartChaos();
                break;
            case 11:
                SetDialogue(dialogue12);
                mnb_dlg10_follow02.follow = false;
                break;
            case 99:
                SetDialogue(dialogue99_0);
                break;
            case 100:
                SetDialogue(dialogue99_1);
                MainMus.SetMainMus(gc_finale.mus_bossfinale2, 0.1f);
                break;
            case 101:
                SetDialogue(dialogue99_2);
                trg_dlg99_2_heli.SetActive(true);
                trg_dlg99_2_playtime.SetActive(true);
                break;
            case 102:
                SetDialogue(dialogue99_3);
                break;
            case 103:
                SetDialogue(outroDialogue);
                break;
        }

        if (SceneManager.GetActiveScene().name == "Finale")
        {
            gc_finale.hud.SetActive(false);
        }
    }

    protected override void NextSlide()
    {
        switch (dialogueType)
        {
            case -1:
                ShowDialogue(CharSide.None);
                break;
            case 0:
            case 1:
            case 2:
            case 3:
                ShowDialogue();
                break;
            case 4:
                switch (remainingSlides)
                {
                    case 0:
                    case 2:
                        ShowDialogue(CharSide.None);
                        break;
                    case 4:
                    case 6:
                    case 8:
                    case 9:
                        ShowDialogue(CharSide.Left);
                        break;
                    default:
                        ShowDialogue();
                        break;
                }
                break;
            case 5:
                ShowDialogue();
                break;
            case 6:
                switch (remainingSlides)
                {
                    case 0:
                    case 2:
                    case 4:
                    case 7:
                        ShowDialogue();
                        break;
                    default:
                        ShowDialogue(CharSide.None);
                        break;
                }
                break;
            case 7:
            case 8:
                ShowDialogue();
                break;
            case 9:
                switch (remainingSlides)
                {
                    case 2:
                    case 3:
                        ShowDialogue(CharSide.Left, "BAL_Happy");
                        break;
                    case 10:
                        ShowDialogue(CharSide.Left, "BAL_Sad");
                        break;
                    case 5:
                    case 6:
                    case 8:
                        ShowDialogue(CharSide.Left, "Pri_talk");
                        break;
                    default:
                        ShowDialogue();
                        break;
                }
                break;
            case 10:
                switch (remainingSlides)
                {
                    case 0:
                    case 5:
                        ShowDialogue(CharSide.Left);
                        break;
                    case 2:
                        ShowDialogue(CharSide.Left, "BAL_Angry");
                        break;
                    case 4:
                        ShowDialogue(CharSide.Left, "BAL_Mad");
                        break;
                    case 6:
                        ShowDialogue(CharSide.Left, "Pri_talk");
                        break;
                    default:
                        ShowDialogue();
                        break;
                }
                break;
            case 11:
                switch (remainingSlides)
                {
                    case 1:
                        ShowDialogue(CharSide.Left, "BAL_Sad");
                        break;
                    case 3:
                        ShowDialogue(CharSide.Both, "BAL_Sad");
                        break;
                    default:
                        ShowDialogue(CharSide.Left, "Pri_talk");
                        break;
                }
                break;
            case 99:
                switch (remainingSlides)
                {
                    case 0:
                    case 2:
                        ShowDialogue();
                        break;
                    default:
                        ShowDialogue(CharSide.Left, "BAL_Sad");
                        break;
                }
                break;
            case 100:
                switch (remainingSlides)
                {
                    case 1:
                    case 10:
                        ShowDialogue();
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        ShowDialogue(CharSide.Left, "BAL_Sad");
                        break;
                    default:
                        ShowDialogue(CharSide.Left);
                        break;
                }
                break;
            case 101:
                switch (remainingSlides)
                {
                    case 0:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        ShowDialogue(CharSide.Left, "Joe_Angry");
                        break;
                    case 1:
                    case 11:
                        ShowDialogue(CharSide.Left, "BAL_HappyEvil");
                        break;
                    case 4:
                    case 5:
                        ShowDialogue(CharSide.Left);
                        break;
                    case 13:
                    case 14:
                    case 15:
                    case 17:
                        ShowDialogue(CharSide.Left, "BAL_Sad");
                        break;
                    default:
                        ShowDialogue();
                        break;
                }

                if (remainingSlides == 15)
                {
                    efx_dlg99_2_helicopter.SetActive(true);
                }
                break;
            case 102:
                switch (remainingSlides)
                {
                    case 1:
                        ShowDialogue();
                        break;
                    case 4:
                        ShowDialogue(CharSide.Left, "BAL_Happy");
                        break;
                    case 5:
                        ShowDialogue(CharSide.Left, "Joe_Angry");
                        break;
                    default:
                        ShowDialogue(CharSide.Left, "Playtime_talk");
                        break;
                }
                break;
            case 103:
                ShowDialogue();
                break;
        }
    }

    protected override void OnDialogueEnd()
    {
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
                GameObject.FindWithTag("GameController").GetComponent<GC_Tragic>().StartCoroutine("ContinueChaos");
                break;
            case 99:
                gc_finale.chapter.GetComponent<TextMeshProUGUI>().text = "Finale";
                gc_finale.chapter.GetComponent<Animator>().Play("NewChapter");
                break;
            case 100:
                gc_finale.StartCoroutine("StartBossIntro");
                break;
            case 101:
                MainMus.SetMainMus(gc_finale.mus_bossfinale2);
                break;
            case 102:
                MainMus.SetMainMus(gc_finale.mus_bossfinale3);
                break;
            case 103:
                SceneManager.LoadScene("MenuOutro");
                Destroy(MainMus.GetMainMus().gameObject);
                break;
        }
    }
}
