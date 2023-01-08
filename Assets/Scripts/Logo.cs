using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    public bool checkFinale;
    public Image logo;
    public Sprite[] logos;

    private IEnumerator Start()
    {
        PlayerPrefs.SetInt("respawn", 0);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        for (int i = 0; i < logos.Length; i++)
        {
            yield return new WaitForSeconds(2f);
            logo.sprite = logos[i];

            if (i >= logos.Length - 1)
            {
                yield return new WaitForSeconds(2f);

                if (checkFinale)
                {
                    SceneManager.LoadScene("FinaleChecker");
                }

                else
                {
                    SceneManager.LoadScene("Warning");
                }
            }
        }
    }
}
