using UnityEngine;

public class CannonBall : EnemyHitbox
{
    [SerializeField]private float speed = 2;
    [SerializeField]private Rigidbody2D m_rigidBody;

    void Start()
    {
        takesDamage = false;
        m_rigidBody.linearVelocity = transform.up * speed;
    }

    void Update()
    {
        m_rigidBody.linearVelocity = transform.up * speed;
    }
}
