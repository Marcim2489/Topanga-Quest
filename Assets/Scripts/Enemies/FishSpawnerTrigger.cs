using UnityEngine;

public class FishSpawnerTrigger : MonoBehaviour
{
    public event System.Action playerEntered;
    public event System.Action playerExited;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerHitbox>()!= null)
        {
            playerEntered?.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerHitbox>()!= null)
        {
            playerExited?.Invoke();
        }
    }
}
