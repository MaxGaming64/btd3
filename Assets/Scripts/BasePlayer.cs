using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    public bool advancedMovement;
    public BasePlayerMovement movementScript;
    public BasePlayerCamera cameraScript;

    void Start()
    {
        LockMouse();
    }

    public void LockMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnlockMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnDisable()
    {
        movementScript.enabled = false;
        cameraScript.enabled = false;
    }

    private void OnEnable()
    {
        movementScript.enabled = true;
        cameraScript.enabled = true;
    }
}