using UnityEngine;
using BTD3Framework;

public class GC_Outro : BaseGameController
{
    public AudioClip ambient;

    void Start()
    {
        Init();
        InitMainMus(ambient);
    }

    void Update()
    {
        pm.allowPause = !ds.dialogue;
    }
}
