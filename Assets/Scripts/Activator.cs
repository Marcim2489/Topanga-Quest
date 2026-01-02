using UnityEngine;

public class Activator : MonoBehaviour
{
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    //     if (enemy != null)
    //     {
    //         enemy.Activate();
    //     }
    // }
    void OnTriggerEnter2D(Collider2D collision)
    {
        DragonSpawner spawner = collision.gameObject.GetComponent<DragonSpawner>();
        if (spawner != null)
        {
            spawner.Spawn();
            return;
        }
        SnowIntensifier s = collision.gameObject.GetComponent<SnowIntensifier>();
        if(s!= null)
        {
            s.Trigger();
            return;
        }
        CoinTrigger c = collision.gameObject.GetComponent<CoinTrigger>();
        if (c != null)
        {
            c.Trigger();
            return;
        }
        RubyTrigger r = collision.gameObject.GetComponent<RubyTrigger>();
        if (r != null)
        {
            r.Trigger();
            return;
        }
        LevelEndTrigger l= collision.gameObject.GetComponent<LevelEndTrigger>();
        if (l != null)
        {
            l.Trigger();
            return;
        }
    }
}
