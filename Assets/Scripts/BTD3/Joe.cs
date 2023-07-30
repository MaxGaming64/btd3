using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Joe : MonoBehaviour
{
    public bool attacking;
    public bool killing;
    private GC_Finale gc;
    private Transform player;
    private NavMeshAgent agent;
    public AudioClip die;
    public Transform diePos;
    public Image fade;
    
    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GC_Finale>();
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (attacking)
        {
            if (!killing)
            {
                if (Vector3.Distance(transform.position, player.position) > 5f)
                {
                    if (PlayerPrefs.GetInt("finaleFix") == 0)
                    {
                        agent.speed = 70f;
                    }

                    else
                    {
                        agent.speed = 20f;
                    }
                }

                else
                {
                    agent.speed = 5f;
                }

                agent.SetDestination(player.position);
            }
        }

        else
        {
            agent.ResetPath();
        }

        if (killing)
        {
            player.GetComponent<BasePlayer>().enabled = false;
            player.position = diePos.position;
            player.rotation = diePos.rotation;
            player.GetComponent<BasePlayer>().cameraScript.transform.localRotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && attacking)
        {
            killing = true;
            AudioSource mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();
            mainMus.Stop();
            mainMus.PlayOneShot(die, 2f);
            StartCoroutine(Die());
            StartCoroutine(Fade());
            StartCoroutine(FadeJoeSmile());
            GameObject.Find("Hud").SetActive(false);
            PlayerPrefs.SetInt("respawn", 1);
        }
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(die.length);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Finale");
    }

    private IEnumerator Fade()
    {
        for (float i = 0f; i >= 0; i += Time.deltaTime * 0.1f)
        {
            fade.color = new Color(0f, 0f, 0f, i);
            yield return null;
        }
    }

    private IEnumerator FadeJoeSmile()
    {
        yield return new WaitForSeconds(die.length - 5f);
        for (float i = 1f; i >= 0; i -= Time.deltaTime * 0.5f)
        {
            gc.joeSprite.color = new Color(1f, 1f, 1f, i);
            yield return null;
        }
    }
}
