using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using BTD3Framework;

public class DS_BTD3 : DialogueSystem
{
    string[] introDialogue =
    {
        "...and you went to his house.",
        "Principal told you his address,",
        "So you ask Principal where he lives.",
        "You search for him, and no luck...",
        "But then, you realize that Baldi is not there."
    };
    string[] dialogue01 =
    {
        "But I think I need to find the key to the door first...",
        "Oh, wait! There's a locked door there!"
    };
    string[] dialogue02 = { "Let me get a closer look..." };
    string[] dialogue03 =
    {
        "I think I'm in some kind of vent...",
        "I've gotta get the hell outta here!"
    };
    string[] dialogue04 =
    {
        "Alright, let's go in.",
        "Wait, there's an opening here; how did I not notice it?",
        "Let's see if there's a way to get outta here."
    };
    string[] dialogue05 =
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
    string[] dialogue06 =
    {
        "I need to find some food, though... I'm starving...",
        "Well, I won't see Joe for a long time, that's for sure!"
    };
    string[] dialogue07 =
    {
        "Don't worry, Baldi! I'll save you!", //0
        "BUT BE CAREFUL, THERE ARE DANGEROUS ALIENS THERE!", //1
        "TO SAVE ME, YOU MUST GO THROUGH PLANET XEN!", //2
        "Oh no! How can I save you?!", //3
        "YES, AND I'M KIDNAPPED BY JOE!!!", //4
        "What?? Is that Baldi?!", //5
        "HELP!!!!!!" //6
    };
    string[] dialogue08 =
    {
        "I gotta get outta here soon...",
        "And what was that alien?"
    };
    string[] dialogue09 =
    {
        "Speaking of Baldi, where is he?",
        "And why does he even have this in the first place??",
        "Why did Baldi never tell us about this?"
    };
    string[] dialogue10 =
    {
        "I don't know...", //0
        "Okay. But what if Joe finds us?", //1
        "We have to go further, and escape out of here.", //2
        "So what are we gonna do now?", //3
        "I decided to check it out myself.", //4
        "After you told me Baldi was gone...", //5
        "But wait, Principal, what are you doing here?", //6
        "I'm so glad you made it through Xen!", //7
        "Player!", //8
        "Principal?!", //9
    };
    string[] dialogue11 =
    {
        "RUN!!!", //0
        "Correction: I'M going to kill ALL OF YOU!!!", //1
        "I'M GONNA KILL YOU FOR THAT!!!", //2
        "He stole it while I was in your brain.", //3
        "Wait, are you slapping with MY ruler?!", //4
        "Oh no... He found us!" //5
    };
    string[] dialogue12 =
    {
        "NOOOOOO!",
        "Go on without me! I'll survive!",
        "We can't leave you here, Principal!"
    };
    string[] dialogue99_0 = //finale intro
    {
        "I think so...",
        "So do we just try to find him?",
        "I think this is where Joe lives."
    };
    string[] dialogue99_1 = //finale bossbattle intro
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
        "Why is your face blue?" //9
    };
    string[] dialogue99_2 = //finale outro 1
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
    string[] dialogue99_3 = //finale outro 2
    {
        "Get in, quick, before Joe gets you!", //playtime, 0
        "NO!!!", //joe mad, 1
        "Just in time!", //baldi happy, 2
        "Principal told me about the whole thing!", //playime, 3
        "Yes, I have come to rescue you!", //playtime, 4
        "Playtime?!" //player, 5
    };
    string[] outroDialogue =
    {
        "Imma head back home. It's 12:00 in the morning already!",
        "This was even crazier than going into Baldi's brain!",
        "It's so amazing that Joe is finally gone!",
        "School sweet school!"
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

    public override void StartDialogue(int DialogueType)
    {
        base.StartDialogue(DialogueType);

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
                player.transform.position = new Vector3(-15f, -110f, 75f);
                player.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                player.enabled = true;
                MainMus.SetMainMus(sfx_dlg5_ambient, 0.5f);
                break;
            case 6:
                ActivateRight();
                anim_right.Play("Player");
                text.text = "Woah! What is this...";
                slideCount = dialogue07.Length;
                player.enabled = false;
                player.transform.position = new Vector3(-45f, -80f, 45f);
                player.transform.rotation = Quaternion.identity;
                player.enabled = true;
                MainMus.SetMainMus(sfx_dlg6_ambient);
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
                efx_dlg10_barrier.SetActive(true);
                RenderSettings.skybox = rfx_dlg10_sky;
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
                ActivateLeft();
                anim_left.Play("Joe");
                text.text = "Well, I guess you idiots somehow found me!";
                slideCount = dialogue99_1.Length;
                MainMus.SetMainMus(gc_finale.mus_bossfinale2, 0.1f);
                break;
            case 101:
                ActivateLeft();
                anim_left.Play("Joe_Angry");
                text.text = "UGH!!!";
                slideCount = dialogue99_2.Length;
                trg_dlg99_2_heli.SetActive(true);
                trg_dlg99_2_playtime.SetActive(true);
                break;
            case 102:
                ActivateLeft();
                anim_left.Play("Playtime_talk");
                text.text = "Hey there!";
                slideCount = dialogue99_3.Length;
                break;
            case 103:
                ActivateRight();
                anim_right.Play("Player");
                text.text = "Ahh!";
                slideCount = outroDialogue.Length;
                break;
        }

        if (SceneManager.GetActiveScene().name == "Finale")
        {
            gc_finale.hud.SetActive(false);
        }
    }

    public override void NextSlide()
    {
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
                ChangeTextAndImageAndChar(dialogue04, dialogueNULLImages, 1);
                break;
            case 4:
                switch (slideCount)
                {
                    case 9:
                    case 7:
                    case 5:
                    case 3:
                    case 0:
                        ChangeTextAndImageAndChar(dialogue05, dialogueNULLImages, 1);
                        break;
                    case 6:
                    case 4:
                    case 2:
                    case 1:
                        ChangeTextAndImageAndChar(dialogue05, dialogueNULLImages, 0);
                        break;
                    case 8:
                        ChangeTextAndImageAndChar(dialogue05, dialogueNULLImages, -1);
                        break;
                }
                break;
            case 5:
                ChangeTextAndImageAndChar(dialogue06, dialogueNULLImages, 1);
                break;
            case 6:
                switch (slideCount)
                {
                    case 6:
                    case 4:
                    case 2:
                    case 1:
                        ChangeTextAndImageAndChar(dialogue07, dialogueNULLImages, -1);
                        break;
                    default:
                        ChangeTextAndImageAndChar(dialogue07, dialogueNULLImages, 1);
                        break;
                }
                break;
            case 7:
                ChangeTextAndImageAndChar(dialogue08, dialogueNULLImages, 1);
                break;
            case 8:
                ChangeTextAndImageAndChar(dialogue09, dialogueNULLImages, 1);
                break;
            case 9:
                switch (slideCount)
                {
                    case 9:
                    case 6:
                    case 3:
                    case 1:
                        ChangeTextAndImageAndChar(dialogue10, dialogueNULLImages, 1);
                        break;
                    case 8:
                    case 7:
                        ChangeTextAndImageAndChar(dialogue10, dialogueNULLImages, 0, "BAL_Happy");
                        break;
                    case 0:
                        ChangeTextAndImageAndChar(dialogue10, dialogueNULLImages, 0, "BAL_Sad");
                        break;
                    case 5:
                    case 4:
                    case 2:
                        ChangeTextAndImageAndChar(dialogue10, dialogueNULLImages, 0, "Pri_talk");
                        break;
                }
                break;
            case 10:
                switch (slideCount)
                {
                    case 5:
                    case 3:
                        ChangeTextAndImageAndChar(dialogue11, dialogue11Images, 1);
                        break;
                    case 4:
                        ChangeTextAndImageAndChar(dialogue11, dialogue11Images, 0, "BAL_Angry");
                        break;
                    case 2:
                        ChangeTextAndImageAndChar(dialogue11, dialogue11Images, 0, "BAL_Mad");
                        break;
                    case 1:
                        ChangeTextAndImageAndChar(dialogue11, dialogue11Images, 0);
                        break;
                    case 0:
                        ChangeTextAndImageAndChar(dialogue11, dialogue11Images, 0, "Pri_talk");
                        break;
                }
                break;
            case 11:
                if (slideCount == 1)
                {
                    ChangeTextAndImageAndChar(dialogue12, dialogueNULLImages, 0, "Pri_talk");
                }

                else
                {
                    ChangeTextAndImageAndChar(dialogue12, dialogueNULLImages, 0, "BAL_Sad");
                }
                break;
            case 99:
                if (slideCount == 1)
                {
                    ChangeTextAndImageAndChar(dialogue99_0, dialogueNULLImages, 1);
                }

                else
                {
                    ChangeTextAndImageAndChar(dialogue99_0, dialogueNULLImages, 0, "BAL_Sad");
                }
                break;
            case 100:
                switch (slideCount)
                {
                    case 9:
                    case 0:
                        ChangeTextAndImageAndChar(dialogue99_1, dialogueNULLImages, 1);
                        break;
                    case 8:
                    case 7:
                    case 6:
                    case 5:
                        ChangeTextAndImageAndChar(dialogue99_1, dialogueNULLImages, 0);
                        break;
                    case 4:
                    case 3:
                    case 2:
                    case 1:
                        ChangeTextAndImageAndChar(dialogue99_1, dialogueNULLImages, 0, "BAL_Sad");
                        break;
                }
                break;
            case 101:
                switch (slideCount)
                {
                    case 10:
                    case 9:
                    case 8:
                    case 7:
                        ChangeTextAndImageAndChar(dialogue99_2, dialogueNULLImages, 0, "Joe_Angry");
                        break;
                    case 16:
                    case 6:
                        ChangeTextAndImageAndChar(dialogue99_2, dialogueNULLImages, 0, "BAL_HappyEvil");
                        break;
                    case 15:
                    case 14:
                    case 11:
                    case 5:
                    case 1:
                        ChangeTextAndImageAndChar(dialogue99_2, dialogueNULLImages, 1);
                        break;
                    case 13:
                    case 12:
                        ChangeTextAndImageAndChar(dialogue99_2, dialogueNULLImages, 0);
                        break;
                    case 4:
                    case 3:
                    case 2:
                    case 0:
                        ChangeTextAndImageAndChar(dialogue99_2, dialogueNULLImages, 0, "BAL_Sad");
                        break;
                }

                if (slideCount == 2)
                {
                    efx_dlg99_2_helicopter.SetActive(true);
                }
                break;
            case 102:
                switch (slideCount)
                {
                    case 5:
                        ChangeTextAndImageAndChar(dialogue99_3, dialogueNULLImages, 1);
                        break;
                    case 4:
                    case 3:
                    case 0:
                        ChangeTextAndImageAndChar(dialogue99_3, dialogueNULLImages, 0, "Playtime_talk");
                        break;
                    case 2:
                        ChangeTextAndImageAndChar(dialogue99_3, dialogueNULLImages, 0, "BAL_Happy");
                        break;
                    case 1:
                        ChangeTextAndImageAndChar(dialogue99_3, dialogueNULLImages, 0, "Joe_Angry");
                        break;
                }
                break;
            case 103:
                ChangeTextAndImageAndChar(outroDialogue, dialogueNULLImages, 1);
                break;
        }
    }

    public override void OnDialogueEnd()
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
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GC_Tragic>().StartCoroutine("ContinueChaos");
                break;
            case 99:
                gc_finale.chapter.GetComponent<TextMeshProUGUI>().text = "Finale";
                gc_finale.chapter.GetComponent<Animator>().Play("NewChapter");
                break;
            case 100:
                gc_finale.StartCoroutine(gc_finale.StartBossIntro());
                break;
            case 101:
                MainMus.SetMainMus(gc_finale.mus_bossfinale2);
                break;
            case 102:
                MainMus.SetMainMus(gc_finale.mus_bossfinale3);
                break;
            case 103:
                SceneManager.LoadScene("MenuOutro");
                Destroy(mainMus.gameObject);
                break;
        }
    }
}
