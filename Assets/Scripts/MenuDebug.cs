using UnityEngine;

public class MenuDebug : MonoBehaviour
{
    private Player player;
    private Transform playerCamera;
    private Vector3 startPosition;
    private Quaternion startRotation;
    
    void Start()
    {
        player = GetComponent<Player>();
        playerCamera = Camera.main.transform;
        startPosition = transform.position;
        startRotation = playerCamera.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            player.enabled = !player.enabled;
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            player.enabled = false;
            player.transform.position = startPosition;
            playerCamera.rotation = startRotation;
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
