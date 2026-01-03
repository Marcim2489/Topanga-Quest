using UnityEngine;

public class BossEndTrigger : MonoBehaviour
{
    [SerializeField]Skullex boss;
    [SerializeField]Rigidbody2D m_rigidbody;
    void Start()
    {
        boss.died+=Fall;
    }

    void Fall()
    {
        m_rigidbody.linearVelocityY = -3;
    }
}
