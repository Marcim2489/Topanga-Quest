using UnityEngine;

public class TopangaFly : MonoBehaviour
{
    [SerializeField]float moveSpeed = 2.5f;
    [SerializeField]float lifeTime = 10;
    [SerializeField]Animator animator;
    [SerializeField]Rigidbody2D rigidBody;
    [SerializeField]float flyUpTime = 0.7f;
    Vector2 direction = new Vector2(1,0);
    float timer;
    bool changedDirection;
    void Start()
    {
        direction = new Vector2(1,0);
        rigidBody.linearVelocity = moveSpeed*direction;
        Destroy(gameObject,lifeTime);
    }

    void Update()
    {
        rigidBody.linearVelocity = moveSpeed*direction;
        timer+=Time.deltaTime;
        if (timer < flyUpTime||changedDirection)
        {
            return;
        }
        int d = Random.Range(1,3);
        if (d == 1)
        {
            direction = new Vector2(1,1).normalized;
            animator.SetTrigger("Up");
        }
        else
        {
            direction = new Vector2(1,-1).normalized;
            animator.SetTrigger("Down");
        }
        changedDirection = true;
    }
}
