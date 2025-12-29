using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public float moveSpeed = 4.2f;
    public Rigidbody2D m_rigidBody;
    public Animator m_animator;
    public SpriteRenderer m_spriteRenderer;
    [SerializeField] protected PlayerHitbox hitbox;
    public event System.Action died;
    public float deathAnimationTime = 1;
    public virtual void Start()
    {
        hitbox.tookHit += TakeDamage;
        LevelLoader.Instance.SetPlayer(this);
    }
    
    public virtual void TakeDamage()
    {
        died?.Invoke();
        DisableHitbox();
    }

    public void DisableHitbox()
    {
        hitbox.gameObject.SetActive(false);
    }
}
