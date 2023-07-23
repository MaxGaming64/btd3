using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GC_Xen : MonoBehaviour
{
    public bool playerDead;
    private float mouseSensitivity;
    private float timeToRandomAmb = -1f;
    private float XRotation;
    public int playerHealth;
    private AudioSource mainMus;
    public DialogueSystem ds;
    public GameObject[] hudItems;
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
            mainMus = GameControllerScript.CreateMainMus(ambient);
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

        chapter.GetComponent<TextMeshProUGUI>().text = "Xen";
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

        FindObjectOfType<PauseManager>().allowPause = !ds.dialogue;

        if (playerHealth > 100)
        {
            playerHealth = 100;
        }
        
        if (playerHealth <= 0f && !playerDead)
        {
            playerDead = true;

            foreach (var component in hudItems)
            {
                component.SetActive(false);
            }

            Transform playerCamera = player.GetComponent<Player>().cameraScript.transform;

            deathCameraRoot.position = playerCamera.position;
            deathCameraRoot.rotation = player.rotation;
            XRotation = playerCamera.eulerAngles.x;
            deathCameraRoot.gameObject.SetActive(true);
            player.gameObject.SetActive(false);
        }

        if (playerDead)
        {
            if (Time.timeScale > 0)
            {
                float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
                float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

                deathCameraRoot.Rotate(Vector3.up * mouseX);

                if (XRotation >= 270f)
                {
                    XRotation -= 360f;
                }

                XRotation -= mouseY;
                XRotation = Mathf.Clamp(XRotation, -90f, 90f);

                deathCamera.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
            }

            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        healthText.text = "Health: " + playerHealth;
    }
}
