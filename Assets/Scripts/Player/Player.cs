using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public int moveSpeed = 400;
    public Rigidbody2D m_rigidBody;
    public Animator m_animator;
    public SpriteRenderer m_spriteRenderer;

    public virtual void TakeDamage()
    {
    }
    public virtual void OnTriggerEnter2D(Collider2D other) 
    {
        // if (other.gameObject.layer != LayerMask.NameToLayer("EnemyHitbox"))
        // {
        //     return;
        // }
        // TakeDamage();
    }
}
