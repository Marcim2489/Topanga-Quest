using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    public event System.Action landedHit;
    public event System.Action tookHit;

    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHitbox enemy = collision.gameObject.GetComponent<EnemyHitbox>();
        if (enemy != null)
        {
            
            if (gameObject.transform.position.y > collision.gameObject.transform.position.y)
            {
                
                enemy.TookHit();
                LandedHit();
                return;
            }

            TookHit();
            enemy.LandedHit();
    }

    }
    public void LandedHit()
    {
        landedHit?.Invoke();
    }
    public void TookHit()
    {
        tookHit?.Invoke();
    }
}
