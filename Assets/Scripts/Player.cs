using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float currentSpeed;
    private float speed = 10f;
    private float runSpeed = 16f;
    private float mouseSensitivity;
    private float gravity = Physics.gravity.y * 2f;
    private bool grounded;
    private CharacterController controller;
    private Vector3 velocity;
    public LayerMask layerMask;
    public Transform Camera;
    public Slider stamina;

    void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
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
            MovementAndLook();
            Sprint();

            if (!grounded)
            {
                velocity.y += gravity * Time.deltaTime;
            }

            controller.Move(velocity * Time.deltaTime);
        }
    }

    void MovementAndLook()
    {
        float x = Input.GetAxisRaw("Strafe");
        float z = Input.GetAxisRaw("Forward");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetKey(KeyCode.Space))
        {
            Camera.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }

        else
        {
            Camera.localRotation = Quaternion.identity;
        }
    }

    void Sprint()
    {
        if (Input.GetButton("Run") & stamina.value > 0f & controller.velocity != Vector3.zero)
        {
            currentSpeed = runSpeed;
            stamina.value -= 10f * Time.deltaTime;
        }

        else
        {
            currentSpeed = speed;

            if (controller.velocity == Vector3.zero)
            {
                stamina.value += 10f * Time.deltaTime;
            }
        }
    }
}