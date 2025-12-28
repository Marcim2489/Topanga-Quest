using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerHitbox>()!= null)
        {
            FindFirstObjectByType<LevelManager>().coinsColected++;
            Destroy(gameObject);
        }
    }
}
