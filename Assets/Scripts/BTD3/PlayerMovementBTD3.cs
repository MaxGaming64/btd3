using UnityEngine;

public class PlayerMovementBTD3 : BasePlayerMovement
{
    public LayerMask layerMaskGel;
    private GC_Finale gc_finale;

    new void Start()
    {
        base.Start();
        
        switch (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
        {
            case "Chapter2":
                jumpHeight = 5f;
                gravity = Physics.gravity.y / 2f;
                break;
            case "Finale":
                gc_finale = FindObjectOfType<GC_Finale>();
                break;
        }
    }

    new void Update()
    {
        base.Update();

        bool groundedOnGel = Physics.Raycast(transform.position, Vector3.down, 0.1f, layerMaskGel);

        if (grounded)
        {
            if (!groundedOnGel && gc_finale != null)
            {
                gc_finale.jumpHigh = false;
                gc_finale.allowKnockout = false;
            }
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
}
