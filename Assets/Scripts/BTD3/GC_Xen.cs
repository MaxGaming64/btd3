using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using BTD3Framework;

public class GC_Xen : BaseGameController
{
    public bool playerDead;
    private float mouseSensitivity;
    private float timeToRandomAmb = -1f;
    private float XRotation;
    public int playerHealth;
    private AudioSource mainMus;
    public GameObject[] hudItems;
    public AudioClip ambient;
    public AudioClip comes;
    public AudioClip alien_squit;
    public AudioClip beamstart2;
    public AudioClip beamstart7;
    public AudioClip heal;
    public Animator fade;
    public GameObject chapter;
    public TextMeshProUGUI healthText;
    public Transform deathCameraRoot;
    public Transform deathCamera;

    void Start()
    {
        if (MainMus.GetMainMus() == null)
        {
            Init(2, chapter, "Xen", fade);
        }

        else
        {
            Init(2, chapter, "Xen");
        }

        mainMus = InitMainMus(ambient);
        mainMus.PlayOneShot(comes, 2f);
        healthText.gameObject.SetActive(true);
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
    }

    void Update()
    {
        pm.allowPause = !(ds.dialogue && playerDead);

        if (timeToRandomAmb < 0f)
        {
            timeToRandomAmb = Random.Range(alien_squit.length, 30);
            mainMus.PlayOneShot(alien_squit);
        }

        if (timeToRandomAmb > 0f)
        {
            timeToRandomAmb -= Time.deltaTime;
        }

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

            Transform playerCamera = player.GetComponent<BasePlayer>().cameraScript.transform;

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

    IEnumerator SpawnAlien(GameObject enemy)
    {
        AudioSource audio = enemy.GetComponent<AudioSource>();
        enemy.SetActive(true);
        audio.PlayOneShot(beamstart2);
        audio.PlayOneShot(beamstart7);
        yield return null;
    }

    IEnumerator MedKit(GameObject medKit)
    {
        if (playerHealth < 100)
        {
            playerHealth += 20;
            MainMus.GetMainMus().PlayOneShot(heal, 2f);
            Destroy(medKit);
            yield return null;
        }
    }
}
