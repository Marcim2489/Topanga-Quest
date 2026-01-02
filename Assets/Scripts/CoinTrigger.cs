using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    [SerializeField]private float speed = 5;
    [SerializeField]private Coin coin;


    public void Trigger()
    {
        Coin c = Instantiate(coin, transform.position, transform.rotation);
        c.gameObject.GetComponent<Rigidbody2D>().linearVelocityX = -speed;
        Destroy(gameObject);
    }
}
