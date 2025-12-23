using System.Threading;
using UnityEngine;

public class BeaterFish : EnemyHitbox
{
    private int direction = 1;
    [SerializeField]private Rigidbody2D m_rigidBody;
    [SerializeField]private float moveSpeed = 3;
    [SerializeField]private float swimCooldown = 1;
    [SerializeField]private SpriteRenderer m_sprite;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=swimCooldown)
        {
            Swim();
        }
    }

    void Swim()
    {
        m_rigidBody.linearVelocityX = direction*moveSpeed;
        timer = 0;
    }
    public void SetDirectionAndSwim(int dir)
    {
        direction = dir;
        if (direction > 0)
        {
            m_sprite.flipX = false;
        }
        else
        {
            m_sprite.flipX = true;
        }
        Swim();
    }
}
