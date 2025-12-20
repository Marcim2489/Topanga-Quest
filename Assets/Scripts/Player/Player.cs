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
}
