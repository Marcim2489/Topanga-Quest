using UnityEngine;

public class KillerDragon : EnemyHitbox
{
    [SerializeField]private float moveSpeed = 3;
    [SerializeField]private Rigidbody2D m_rigidBody;

    void Start()
    {
        m_rigidBody.linearVelocityX = -moveSpeed;
    }
}
