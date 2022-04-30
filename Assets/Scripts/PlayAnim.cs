using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public string animName;

    void Start()
    {
        GetComponent<Animator>().Play(animName);
    }
}
