using UnityEngine;

public class Landmark : MonoBehaviour
{
    void Start()
    {
        var keeper = FindObjectOfType<LandmarkKeeper>();
        var player = FindObjectOfType<BasePlayer>().transform;

        if (keeper != null)
        {
            player.position += keeper.pos;
            player.rotation = Quaternion.Euler(transform.eulerAngles + keeper.rot);
            Destroy(keeper.gameObject);
        }
    }
}
