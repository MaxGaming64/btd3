using UnityEngine;
using UnityEngine.UI;

public class Hover : MonoBehaviour
{
    public bool door;
    private float distance;
    private Image reticle_hover;

    void Start()
    {
        reticle_hover = GameObject.Find("Reticle_hover").GetComponent<Image>();
    }

    void OnMouseOver()
    {
        if (door)
        {
            distance = 15f;
        }

        else
        {
            distance = 10f;
        }
        
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < distance && Time.timeScale > 0f)
        {
            reticle_hover.color = Color.white;
        }

        else
        {
            MouseExit();
        }
    }

    void OnMouseExit()
    {
        MouseExit();
    }

    public void MouseExit()
    {
        reticle_hover.color = new Color(255, 255, 255, 0);
    }
}