using UnityEngine;

public class TopangaRun : MonoBehaviour
{
    [SerializeField]Rigidbody2D rigidBody;
    [SerializeField]float moveSpeed =4.15f;
    [SerializeField]float lifeTime = 10;

    void Start()
    {
        rigidBody.linearVelocityX = moveSpeed;
        Destroy(gameObject,lifeTime);
    }

}
