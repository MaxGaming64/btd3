using UnityEngine;
using UnityEngine.UI;

public class BasePlayerMovement : MonoBehaviour
{
    protected float currentSpeed;
    protected float speed = 16f;
    protected float runSpeed = 24f;
    protected float speedMultiplier = 1f;
    protected float jumpHeight = 1.75f;
    protected float gravity = Physics.gravity.y;
    protected bool grounded;
    protected BasePlayer player;
    protected CharacterController controller;
    protected Vector3 velocity;
    protected Slider stamina;

    protected void Start()
    {
        player = GetComponent<BasePlayer>();
        controller = GetComponent<CharacterController>();
        stamina = FindObjectOfType<StaminaSlider>().GetComponent<Slider>();
    }

    protected void Update()
    {
        grounded = controller.isGrounded;

        if (grounded)
        {
            if (velocity.y < 0f)
            {
                velocity.y = -2f;
            }
        }

        if (Time.timeScale > 0f)
        {
            Move();
            Sprint();

            if (!grounded)
            {
                velocity.y += gravity * Time.deltaTime;
            }

            controller.Move(velocity * Time.deltaTime);
        }
    }

    protected void Move()
    {
        float x = Input.GetAxisRaw("Strafe");
        float z = Input.GetAxisRaw("Forward");
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * currentSpeed * speedMultiplier * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && grounded && player.advancedMovement)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    protected void Sprint()
    {
        if (Input.GetButton("Run") && stamina != null && stamina.value > 0f && controller.velocity != Vector3.zero)
        {
            currentSpeed = runSpeed;
            stamina.value -= 10f * Time.deltaTime;
        }

        else
        {
            currentSpeed = speed;

            if (controller.velocity == Vector3.zero && stamina != null)
            {
                stamina.value += 20f * Time.deltaTime;
            }
        }
    }

    public void SetSpeedMultiplier(float speedMultiplier)
    {
        this.speedMultiplier = speedMultiplier;
    }
}
