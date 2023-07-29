using UnityEngine;
using UnityEngine.SceneManagement;
using BTD3Framework;

public class FinaleChecker : BaseGameController
{
    private bool loadFinale;
    public Transform testPlayer;
    
    void Start()
    {
        GameObject mainMus = GameObject.FindGameObjectWithTag("MainMus");
        
        if (mainMus != null)
        {
            Destroy(mainMus);
        }
    }

    void Update()
    {
        testPlayer.position -= Vector3.right * 16f * Time.deltaTime;
    }

    void Pass()
    {
        if (!loadFinale)
        {
            loadFinale = true;
            PlayerPrefs.SetInt("finaleFix", 0);
            SceneManager.LoadSceneAsync("Warning");
        }
    }
}
