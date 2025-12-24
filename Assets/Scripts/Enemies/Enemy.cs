using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]protected int maxHealth = 1;
    protected int currentHealth;
    [SerializeField]protected EnemyHitbox hitbox;
    [SerializeField]protected Rigidbody2D m_rigidBody;
    [SerializeField]protected SpriteRenderer m_sprite;
    [SerializeField]protected Animator m_animator;

    public virtual void Start()
    {
        currentHealth = maxHealth;
        hitbox.tookHit += TakeDamage;
    }
    public virtual void TakeDamage()
    {
        currentHealth --;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }

    public virtual void Activate()
    {
    }
}
