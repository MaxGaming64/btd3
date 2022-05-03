using UnityEngine;

public class TragicShakeTrigger : MonoBehaviour
{
    public Animator anim;
    public string num;
    
    private void OnTriggerEnter(Collider other)
    {
        anim.Play(num);
        Destroy(gameObject);
    }
}
