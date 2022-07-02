using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinaleChecker : MonoBehaviour
{
    private float timer = 10f;
    private bool loadFinale;
    public TextMeshProUGUI timerText;
    public Transform player;
    
    void Start()
    {
        /*if (PlayerPrefs.GetInt("hasEverCheckedFinale") == 1 & !loadFinale)
        {
            loadFinale = true;
            SceneManager.LoadSceneAsync("Finale");
        }*/

        GameObject mainMus = GameObject.FindGameObjectWithTag("MainMus");
        
        if (mainMus != null)
        {
            Destroy(mainMus);
        }
    }

    void Update()
    {
        player.position -= Vector3.right * 16f * Time.deltaTime;
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 & !loadFinale)
        {
            loadFinale = true;
            PlayerPrefs.SetInt("hasEverCheckedFinale", 1);
            SceneManager.LoadSceneAsync("Finale");
        }

        timerText.text = "Please wait.\nAbout " + Mathf.CeilToInt(timer) + " seconds remaining.";
    }
}
