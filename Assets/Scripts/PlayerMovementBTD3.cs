using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovementBTD3 : MonoBehaviour
{
    private float currentSpeed;
    private float speed = 10f;
    private float runSpeed = 16f;
    private float speedMultiplier = 1f;
    private float jumpHeight = 1.75f;
    private float gravity = Physics.gravity.y;
    private bool grounded;
    private Player player;
    private CharacterController controller;
    private Vector3 velocity;
    public LayerMask layerMaskGel;
    private Slider stamina;
    private GC_Finale gc_finale;

    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Chapter2":
                jumpHeight = 5f;
                gravity = Physics.gravity.y / 2f;
                break;
            case "Finale":
                gc_finale = FindObjectOfType<GC_Finale>();
                break;
        }

        player = GetComponent<Player>();
        controller = GetComponent<CharacterController>();
        stamina = player.stamina;
    }

    void Update()
    {
        grounded = controller.isGrounded;
        bool groundedOnGel = Physics.Raycast(transform.position, Vector3.down, 0.1f, layerMaskGel);

        if (grounded)
        {
            if (velocity.y < 0f)
            {
                velocity.y = -2f;
            }

            if (!groundedOnGel && gc_finale != null)
            {
                gc_finale.jumpHigh = false;
                gc_finale.allowKnockout = false;
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

        if (groundedOnGel && gc_finale != null)
        {
            if (gc_finale.jumpHigh)
            {
                velocity.y = Mathf.Sqrt(50f * -2f * gravity);
            }

            else
            {
                velocity.y = Mathf.Sqrt(5f * -2f * gravity);
            }

            gc_finale.StartCoroutine("JumpHighAudio");
        }
    }

    void Move()
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

    void Sprint()
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
