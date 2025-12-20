using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public event System.Action landedHit;
    public event System.Action tookHit;


    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     PlayerHitbox player = collision.gameObject.GetComponent<PlayerHitbox>();
    //     if (player != null)
    //     {
            
    //         if (gameObject.transform.position.y <= collision.gameObject.transform.position.y)
    //         {
                
    //             player.TookHit();
    //             LandedHit();
    //             return;
    //         }
    //     }
    // }

    public void LandedHit()
    {
        landedHit?.Invoke();
    }
    public void TookHit()
    {
        tookHit?.Invoke();
    }
}