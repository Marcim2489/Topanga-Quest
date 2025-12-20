using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private int maxHealth = 1;
    private int currentHealth;
    [SerializeField]private EnemyHitbox hitbox;
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

    // public virtual void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.layer != LayerMask.NameToLayer("PlayerHitbox"))
    //     {
    //         return;
    //     }
    //     other.gameObject.GetComponent<PlayerHitbox>().LandedHit();
    //     TakeDamage();
    // }

}
