using UnityEngine;

public class DragonProjectile : EnemyHitbox
{
    [SerializeField]private float lifeTime = 10;
    [SerializeField]private Rigidbody2D m_rigidBody;
    [SerializeField]private float speed = 2;
    public Player player;

    void Start()
    {
        m_rigidBody.linearVelocity = (player.gameObject.transform.position-transform.position).normalized * speed;
        Destroy(gameObject,lifeTime);
    }
}
