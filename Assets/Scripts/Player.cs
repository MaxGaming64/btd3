using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private bool finale;
    private CharacterController controller;
    private Vector3 velocity;
    public LayerMask layerMask;
    public LayerMask layerMaskGel;
    public Transform Camera;
    public Slider stamina;
    private JumpHighTrigger jumpHigh;

    void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");

        switch (SceneManager.GetActiveScene().name)
        {
            case "Chapter2":
                xen = true;
                gravity = Physics.gravity.y / 2;
                break;
            case "Finale":
                finale = true;
                jumpHigh = GameObject.Find("JumpHighTrigger").GetComponent<JumpHighTrigger>();
                break;
        }

        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        grounded = Physics.CheckSphere(transform.position, -0.2f, layerMask);

        if (grounded)
        {
            if (velocity.y < 0f)
            {
                velocity.y = 0f;
            }

            if (finale)
            {
                jumpHigh.jumpHigh = false;
                jumpHigh.knockoutTrigger.allowKnockout = false;
            }
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

        if (Physics.CheckSphere(transform.position, -0.2f, layerMaskGel) & finale)
        {
            if (jumpHigh.jumpHigh)
            {
                velocity.y = Mathf.Sqrt(50f * -2f * gravity);
            }

            else
            {
                velocity.y = Mathf.Sqrt(5f * -2f * gravity);
            }
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Strafe");
        float z = Input.GetAxisRaw("Forward");
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) & grounded & (xen | finale))
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

        if (xen | finale)
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
                stamina.value += 20f * Time.deltaTime;
            }
        }
    }
}