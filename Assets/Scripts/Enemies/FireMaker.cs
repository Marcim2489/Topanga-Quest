using UnityEngine;

public class FireMaker : MonoBehaviour
{
    [SerializeField]private float fireCooldown = 1;
    [SerializeField]private float startUp = 1;
    [SerializeField]private float fireDuration = 1;
    private float timer;
    private bool canFire;
    private bool fireActive;
    [SerializeField]private Animator m_animator;
    
    void Start()
    {
        if (startUp <= 0)
        {
            canFire = true;
            timer = fireCooldown;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (fireActive)
        {
            if (timer >= fireDuration+0.5f)
            {
                m_animator.SetTrigger("Finish");
                timer = 0;
                fireActive = false;
            }
            else
            {
                return;
            }
        }
        if (canFire == false)
        {
            if (timer >= startUp)
            {
                canFire = true;
                timer = fireCooldown;
            }
            else
            {
                return;
            }
        }
        
        if(timer >= fireCooldown)
        {
            m_animator.SetTrigger("Start");
            timer = 0;
            fireActive = true;
        }
    }
}
