using UnityEngine;

public class TopangaBubble : MonoBehaviour
{
    [SerializeField]float moveSpeed = 2.5f;
    [SerializeField]float lifeTime = 10;
    [SerializeField]Animator animator;
    [SerializeField]Rigidbody2D rigidBody;
    [SerializeField]float jumpForce;
    [SerializeField]float jumpTime;
    [SerializeField]float maxFallSpeed;
    float timer;

    void Start()
    {
        rigidBody.linearVelocityX = moveSpeed;
        Jump();
        Destroy(gameObject,lifeTime);
    }

    void FixedUpdate()
    {
        
        timer+=Time.deltaTime;
        if(timer >= jumpTime)
        {
            Jump();
        }
        if (rigidBody.linearVelocityY < -maxFallSpeed)
        {
            rigidBody.linearVelocityY = -maxFallSpeed;
        }
    }
    void Jump()
    {
        rigidBody.linearVelocityY = jumpForce;
        animator.SetTrigger("Jump");
        timer = 0;
    }
}
