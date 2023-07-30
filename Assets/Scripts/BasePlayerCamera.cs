using UnityEngine;

public class BasePlayerCamera : MonoBehaviour
{
    private float mouseSensitivity;
    private float XRotation;
    private BasePlayer player;

    private void OnEnable()
    {
        XRotation = transform.eulerAngles.x;

        if (XRotation >= 270f)
        {
            XRotation -= 360f;
        }
    }

    void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
        player = GetComponentInParent<BasePlayer>();
    }

    void Update()
    {
        if (Time.timeScale > 0f)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            player.transform.Rotate(Vector3.up * mouseX);

            XRotation -= mouseY;
            XRotation = Mathf.Clamp(XRotation, -90, 90f);

            if (player.advancedMovement)
            {
                transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
            }

            else
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                }

                else
                {
                    transform.localRotation = Quaternion.identity;
                }
            }
        }
    }
}
