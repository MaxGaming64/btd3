using UnityEngine;
using UnityEngine.SceneManagement;

public class YTDemoEnd : MonoBehaviour
{
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
            SceneManager.LoadScene("MenuLoader");
       } 
    }
}
