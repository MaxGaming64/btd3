using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GC_Xen : MonoBehaviour
{
    public bool paused;
    public bool playerDead;
    private float mouseSensitivity;
    private float timeToRandomAmb = -1f;
    private float XRotation;
    public int playerHealth;
    public GameObject pauseCanvas;
    private AudioSource mainMus;
    public DialogueSystem ds;
    public AudioClip ambient;
    public AudioClip comes;
    public AudioClip alien_squit;
    public Animator fade;
    public GameObject chapter;
    public TextMeshProUGUI healthText;
    public Transform player;
    public Transform deathCameraRoot;
    public Transform deathCamera;

    void Start()
    {
        if (PlayerPrefs.GetInt("chapter") < 2)
        {
            PlayerPrefs.SetInt("chapter", 2);
        }

        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");

        if (GameObject.FindGameObjectWithTag("MainMus") == null)
        {
            mainMus = new GameObject().AddComponent<AudioSource>();
            mainMus.gameObject.name = "MainMus";
            mainMus.gameObject.tag = "MainMus";
            mainMus.loop = true;
            mainMus.clip = ambient;
            mainMus.Play();
            DontDestroyOnLoad(mainMus);

            fade.Play("Out");
        }

        else
        {
            mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();

            if (mainMus.clip != ambient)
            {
                mainMus.clip = ambient;
                mainMus.Play();
            }
        }

        mainMus.PlayOneShot(comes, 2f);
        healthText.gameObject.SetActive(true);

        chapter.GetComponent<TMPro.TextMeshProUGUI>().text = "Xen";
        chapter.GetComponent<Animator>().Play("NewChapter");
    }

    void Update()
    {
        if (timeToRandomAmb < 0f)
        {
            timeToRandomAmb = Random.Range(alien_squit.length, 30);
            mainMus.PlayOneShot(alien_squit);
        }

        if (timeToRandomAmb > 0f)
        {
            timeToRandomAmb -= Time.deltaTime;
        }
        
        if (Input.GetButtonDown("Pause") & !ds.dialogue)
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
            SceneManager.LoadScene("MenuLoader");
        }

        if (playerHealth > 100)
        {
            playerHealth = 100;
        }
        
        if (playerHealth <= 0f & !playerDead)
        {
            playerDead = true;

            var ui = FindObjectsOfType<Canvas>();

            foreach (var component in ui)
            {
                component.enabled = false;
            }

            deathCameraRoot.position = player.position + Vector3.up * 0.4f;
            deathCameraRoot.gameObject.SetActive(true);
            player.gameObject.SetActive(false);
        }

        if (playerDead)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            deathCameraRoot.Rotate(Vector3.up * mouseX);

            XRotation -= mouseY;
            XRotation = Mathf.Clamp(XRotation, -90f, 90f);

            deathCamera.localRotation = Quaternion.Euler(XRotation, 0f, 0f);

            if (Input.GetMouseButtonDown(0) | Input.GetMouseButtonDown(1))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        healthText.text = "Health: " + playerHealth;
    }
}
