using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : MonoBehaviour
{
    private BasePlayer player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
    }

    void Update()
    {
        if (!player.movementScript.enabled || !player.gameObject.activeSelf)
        {
            GetComponent<Slider>().value += 20f * Time.deltaTime;
        }
    }
}
