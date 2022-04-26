using UnityEngine;
using UnityEngine.SceneManagement;

public class WarningScreenScript : MonoBehaviour
{
	void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update()
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("MainMenu");
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}