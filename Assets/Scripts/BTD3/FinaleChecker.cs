using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinaleChecker : MonoBehaviour
{
    private bool loadFinale;
    public Transform player;
    public Transform passTrigger;
    
    void Start()
    {
        /*if (PlayerPrefs.GetInt("hasEverCheckedFinale") == 1 && !loadFinale)
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
    }

    public void Pass()
    {
        if (!loadFinale)
        {
            loadFinale = true;
            //PlayerPrefs.SetInt("hasEverCheckedFinale", 1);
            PlayerPrefs.SetInt("finaleFix", 0);
            SceneManager.LoadSceneAsync("Warning");
        }
    }
}
