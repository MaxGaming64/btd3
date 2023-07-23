using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroText : MonoBehaviour
{
    public int slideCount;
    public string[] dialoge;
    private TextMeshProUGUI text;
    public GameObject mainMus;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(mainMus);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (slideCount >= 0)
            {
                slideCount --;
                
                if (slideCount >= 0)
                {
                    text.text = dialoge[slideCount];
                }
            }

            if (slideCount < 0)
            {
                text.text = "LOADING";
            }
        }

        if (slideCount < 0)
        {
            SceneManager.LoadScene("Mansion");
        }
    }
}