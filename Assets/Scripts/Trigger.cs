using UnityEngine;
using BTD3Framework;

public class Trigger : MonoBehaviour
{
    private BaseGameController gc;
    public string exec;
    public GameObject args;
    public bool dontDestroyOnTrigger;

    void Start()
    {
        gc = FindObjectOfType<BaseGameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gc.StartCoroutine(exec, args);

            if (!dontDestroyOnTrigger)
            {
                Destroy(this);
            }
        }
    }
}
