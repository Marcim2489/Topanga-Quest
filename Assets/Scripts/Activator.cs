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
        }
    }
}
