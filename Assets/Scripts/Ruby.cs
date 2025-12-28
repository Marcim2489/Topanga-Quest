using UnityEngine;

public class Ruby : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerHitbox>()!= null)
        {
            FindFirstObjectByType<LevelManager>().rubyColected = true;
            Destroy(gameObject);
        }
    }
}
