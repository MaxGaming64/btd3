using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float currentSpeed;
    private float speed = 10f;
    private float runSpeed = 16f;
    private float mouseSensitivity;
    private float jumpHeight = 5f;
    private float XRotation;
    private float gravity = Physics.gravity.y;
    private bool grounded;
    private bool xen;
    private CharacterController controller;
    private Vector3 velocity;
    public LayerMask layerMask;
    public Transform Camera;
    public Slider stamina;

    void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Chapter2")
        {
            xen = true;
            gravity = Physics.gravity.y / 2;
        }

        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        grounded = Physics.CheckSphere(transform.position, -0.2f, layerMask);

        if (grounded & velocity.y < 0f)
        {
            velocity.y = 0f;
        }

        if (Time.timeScale > 0f)
        {
            Move();
            Look();
            Sprint();

            if (!grounded)
            {
                velocity.y += gravity * Time.deltaTime;
            }

            controller.Move(velocity * Time.deltaTime);
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Strafe");
        float z = Input.GetAxisRaw("Forward");
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) & grounded & xen)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        if (xen)
        {
            Camera.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        }

        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Camera.localRotation = Quaternion.Euler(0f, 180f, 0f);
            }

            else
            {
                Camera.localRotation = Quaternion.identity;
            }
        }
    }

    void Sprint()
    {
        if (Input.GetButton("Run") & stamina != null && stamina.value > 0f & controller.velocity != Vector3.zero)
        {
            currentSpeed = runSpeed;
            stamina.value -= 10f * Time.deltaTime;
        }

        else
        {
            currentSpeed = speed;

            if (controller.velocity == Vector3.zero & stamina != null)
            {
                stamina.value += 10f * Time.deltaTime;
            }
        }
    }
}