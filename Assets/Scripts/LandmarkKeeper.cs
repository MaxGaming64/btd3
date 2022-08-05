using UnityEngine;

public class LandmarkKeeper : MonoBehaviour
{
    public Vector3 pos;
    public Vector3 rot;

    public static LandmarkKeeper CreateLandmarkKeeper(Vector3 pos, Vector3 rot)
    {
        var keeper = new GameObject().AddComponent<LandmarkKeeper>();

        keeper.pos = pos;
        keeper.rot = rot;
        DontDestroyOnLoad(keeper);

        return keeper;
    }
}
