using System.Collections;
using UnityEngine;
using BTD3Framework;

public class GC_Mansion : BaseGameController
{
    private bool elevActive;
    public bool lockDoor01_open;
    private AudioSource mainMus;
    public AudioClip mus_school;
    public AudioClip tube_suck;
    public AudioClip sfx_falldown;
    public AudioClip zapmachine;
    public AudioClip alienwind;
    public MeshRenderer lockDoor01;
    public Material SwingDoor60;
    public Material button_click;
    public Material xenSky;
    public Transform elev;
    public GameObject cutsceneCam;
    public GameObject elevBarrier;
    public Animator fallFloorAnim;

    private void Start()
    {
        Init();
        mainMus = MainMus.CreateMainMus(mus_school, 0.7f, 0.1f);
        ds.StartDialogue(-1);
    }

    private void Update()
    {
        pm.allowPause = !ds.dialogue;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Button_opendoor01" && Vector3.Distance(player.position, hit.transform.position) < 10f && !lockDoor01_open)
                {
                    lockDoor01_open = true;
                    Material[] mat = new Material[3];
                    mat[0] = lockDoor01.materials[0];
                    mat[1] = lockDoor01.materials[1];
                    mat[2] = SwingDoor60;
                    lockDoor01.materials = mat;
                    ds.StartDialogue(1);
                    WorldFunctions.ButtonClick(hit);
                }
            }
        }

        if (elevActive)
        {
            elev.position = Vector3.MoveTowards(elev.position, new Vector3(-45f, -80f, 45f), 5f * Time.deltaTime);
        }
    }

    IEnumerator FallDown()
    {
        player.gameObject.SetActive(false);
        cutsceneCam.SetActive(true);
        player.position = new Vector3(5f, -5f, 45f);
        player.rotation = Quaternion.identity;
        fallFloorAnim.enabled = true;
        MainMus.SetMainMus(tube_suck);
        mainMus.PlayOneShot(sfx_falldown, 0.2f);
        yield return new WaitForSeconds(2f);
        cutsceneCam.SetActive(false);
        player.gameObject.SetActive(true);
    }

    IEnumerator XenElev()
    {
        elevActive = true;
        elevBarrier.SetActive(true);
        RenderSettings.skybox = xenSky;
        Destroy(FindObjectOfType<SkyCamera>().gameObject);
        MainMus.SetMainMus(zapmachine);
        yield return new WaitForSeconds(6f);
        MainMus.SetMainMus(alienwind);
        yield return new WaitForSeconds(2f);
        ds.StartDialogue(6);
    }
}
