using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : MonoBehaviour
{
    private Player player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (!player.movementScript.enabled || !player.gameObject.activeSelf)
        {
            GetComponent<Slider>().value += 20f * Time.deltaTime;
        }
    }
}
