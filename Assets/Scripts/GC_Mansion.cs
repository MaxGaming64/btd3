using UnityEngine;
using UnityEngine.SceneManagement;

public class GC_Mansion : MonoBehaviour
{
    private float timeToEnablePlayer;
    public bool paused;
    public bool lockDoor01_open;
    private AudioSource audioSource;
    private AudioSource mainMus;
    public AudioClip mus_school;
    public AudioClip tube_suck;
    public AudioClip sfx_falldown;
    public GameObject pauseCanvas;
    public MeshRenderer lockDoor01;
    public Material SwingDoor60;
    public Material button_click;
    public DialogeSystem dialogeSystem;
    private Transform player;
    public GameObject cutsceneCam;
    public Animator fallFloorAnim;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if (GameObject.FindGameObjectWithTag("MainMus") == null)
        {
            mainMus = new GameObject().AddComponent<AudioSource>();
            mainMus.gameObject.name = "MainMus";
            mainMus.gameObject.tag = "MainMus";
            mainMus.pitch = 0.1f;
            mainMus.volume = 0.7f;
            mainMus.loop = true;
            mainMus.clip = mus_school;
            mainMus.Play();
            DontDestroyOnLoad(mainMus);
        }

        else
        {
            mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause") & !dialogeSystem.dialoge)
        {
            if (paused)
            {
                paused = false;
                Time.timeScale = 1f;
                pauseCanvas.SetActive(false);
            }

            else
            {
                paused = true;
                Time.timeScale = 0f;
                pauseCanvas.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) & paused)
        {
            Time.timeScale = 1f;
            Destroy(mainMus.gameObject);
            SceneManager.LoadScene("MainMenu");
        }
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Button_opendoor01" & Vector3.Distance(player.position, hit.transform.position) < 10f & !lockDoor01_open)
                {
                    lockDoor01_open = true;
                    Material[] mat = new Material[3];
                    mat[0] = lockDoor01.materials[0];
                    mat[1] = lockDoor01.materials[1];
                    mat[2] = SwingDoor60;
                    lockDoor01.materials = mat;
                    hit.transform.GetComponent<MeshRenderer>().material = button_click;
                    Hover hover = hit.transform.GetComponent<Hover>();
                    hover.MouseExit();
                    Destroy(hover);
                    dialogeSystem.StartDialoge(1);
                }
            }
        }

        if (timeToEnablePlayer > 0f)
        {
            timeToEnablePlayer -= Time.deltaTime;
        }

        if (timeToEnablePlayer < 0f & !player.gameObject.activeSelf)
        {
            cutsceneCam.SetActive(false);
            player.gameObject.SetActive(true);
        }
    }

    public void FallDown()
    {
        player.gameObject.SetActive(false);
        cutsceneCam.SetActive(true);
        timeToEnablePlayer = 2f;
        player.position = new Vector3(5f, -5f, 45f);
        fallFloorAnim.enabled = true;
        mainMus.clip = tube_suck;
        mainMus.pitch = 1f;
        mainMus.volume = 1f;
        mainMus.Play();
        audioSource.PlayOneShot(sfx_falldown, 0.2f);
    }
}