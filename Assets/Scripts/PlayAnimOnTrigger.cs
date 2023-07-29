using UnityEngine;

public class PlayAnimOnTrigger : MonoBehaviour
{
    public Animator anim;
    public string animName;
    public bool dontDestroyOnTrigger;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play(animName);
            
            if (!dontDestroyOnTrigger)
            {
                Destroy(gameObject);
            }
        }
    }
}
