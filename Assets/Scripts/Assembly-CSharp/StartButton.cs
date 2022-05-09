using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartButton : MonoBehaviour
{
    public int chapter;
    public string custom;
    private Button button;
    
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartGame);
        
        if (PlayerPrefs.GetInt("chapter") == 0)
        {
            PlayerPrefs.SetInt("chapter", 1);
        }

        if (chapter > PlayerPrefs.GetInt("chapter"))
        {
            GetComponent<Button>().interactable = false;
            GetComponentInChildren<TextMeshProUGUI>().color = Color.grey;
        }
    }

    public void StartGame()
	{
        if (custom == string.Empty)
        {
            SceneManager.LoadSceneAsync("Chapter" + chapter);
        }

        else
        {
            SceneManager.LoadSceneAsync(custom);
        }
	}
}