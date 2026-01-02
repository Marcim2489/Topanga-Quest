using UnityEngine;

public class Deleter : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Enemy>() != null)
        {
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Enemy>() != null)
        {
            Destroy(collision.gameObject);
            return;
        }
        if(collision.gameObject.GetComponent<EnemyHitbox>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
