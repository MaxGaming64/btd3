using UnityEngine;
using TMPro;

namespace BTD3Framework
{
    public class MainMus : MonoBehaviour
    {
        public static AudioSource CreateMainMus(AudioClip clip, float volume = 1f, float pitch = 1f, bool loop = true)
        {
            AudioSource mainMus = new GameObject().AddComponent<AudioSource>();
            mainMus.name = "MainMus";
            mainMus.tag = "MainMus";
            SetMainMus(clip, volume, pitch, loop);
            DontDestroyOnLoad(mainMus.gameObject);
            return mainMus;
        }

        public static AudioSource GetMainMus()
        {
            try
            {
                return GameObject.FindWithTag("MainMus").GetComponent<AudioSource>();
            }

            catch
            {
                return null;
            }
        }

        public static AudioSource SetMainMus(AudioClip clip, float volume = 1f, float pitch = 1f, bool loop = true)
        {
            AudioSource mainMus = GetMainMus();
            
            mainMus.loop = loop;
            mainMus.volume = volume;
            mainMus.pitch = pitch;
            mainMus.clip = clip;
            mainMus.Play();
            return mainMus;
        }
    }

    public class WorldFunctions : MonoBehaviour
    {
        public static void ButtonClick(RaycastHit hit)
        {
            hit.transform.GetComponent<MeshRenderer>().material = (Material)Resources.Load("materials/ButtonPressed");
            Hover hover = hit.transform.GetComponent<Hover>();
            hover.MouseExit();
            Destroy(hover);
        }
    }

    public class BaseGameController : MonoBehaviour
    {
        protected DialogueSystem ds;
        protected PauseManager pm;
        protected Transform player;
        protected Player playerScript;

        protected void Init(int chapter = 0, GameObject text = null, string title = null, Animator fadeAnim = null)
        {
            ds = FindObjectOfType<DialogueSystem>(true);
            pm = FindObjectOfType<PauseManager>();
            player = FindObjectOfType<Player>().transform;
            playerScript = FindObjectOfType<Player>();

            if (chapter != 0 && PlayerPrefs.GetInt("chapter") < chapter)
            {
                PlayerPrefs.SetInt("chapter", chapter);
            }

            if (!(text == null || title == null))
            {
                text.GetComponent<TextMeshProUGUI>().text = title;
                text.GetComponent<Animator>().Play("NewChapter");
            }

            if (fadeAnim != null)
            {
                fadeAnim.Play("Out");
            }
        }

        protected AudioSource InitMainMus(AudioClip clip = null, float volume = 1f, float pitch = 1f, bool loop = true)
        {
            AudioSource mainMus;

            if (MainMus.GetMainMus() == null)
            {
                mainMus = MainMus.CreateMainMus(clip, volume, pitch, loop);
            }

            else
            {
                mainMus = MainMus.SetMainMus(clip, volume, pitch, loop);
            }

            return mainMus;
        }
    }
}
