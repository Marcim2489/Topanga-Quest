using UnityEngine;

public class CannonBall : EnemyHitbox
{
    public float speed = 2;
    public Rigidbody2D m_rigidBody;
    public float lifeTime = 5;
    public void Shoot()
    {
        takesDamage = false;
        m_rigidBody.linearVelocity = transform.up * speed;
        Destroy(gameObject,lifeTime);
    }

}
