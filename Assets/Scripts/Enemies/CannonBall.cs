using UnityEngine;

public class CannonBall : EnemyHitbox
{
    [SerializeField]private float speed = 2;
    [SerializeField]private Rigidbody2D m_rigidBody;
    public float lifeTime = 5;
    void Start()
    {
        takesDamage = false;
        m_rigidBody.linearVelocity = transform.up * speed;
        Destroy(gameObject,lifeTime);
    }

    void Update()
    {
        m_rigidBody.linearVelocity = transform.up * speed;
    }
}
