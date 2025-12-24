using UnityEngine;

public class KillerDragon : Enemy
{
    public float moveSpeed = 3;

    public override void Start()
    {
        m_rigidBody.linearVelocityX = -moveSpeed;
    }
}
