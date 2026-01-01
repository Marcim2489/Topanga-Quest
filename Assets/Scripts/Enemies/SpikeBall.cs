using UnityEngine;

public class SpikeBall : EnemyHitbox
{
    [SerializeField]private bool vertical = true;
    [SerializeField]private float distance = 0.5f;
    [SerializeField]private float moveSpeed = 2;
    [SerializeField]private Rigidbody2D m_rigidBody;
    private int direction = 1;
    private float lastPosition;
    private float distanceMoved;
    private Vector3 initialPosition;
    private bool isRunning;
    void Start()
    {
        isRunning = true;
        initialPosition = transform.position;
        if (vertical)
        {
            // targetPosition = initialPosition + Vector3.up* distance;
            lastPosition = transform.position.y;
        }
        else
        {
            // targetPosition = initialPosition + Vector3.right* distance;
            lastPosition = transform.position.x;
        }
        if (moveSpeed == 0 || distance == 0)
        {
            return;
        }
        StartMovement();
    }

    void FixedUpdate()
    {
        if (moveSpeed == 0 || distance == 0)
        {
            return;
        }
        
        if (vertical)
        {
            distanceMoved += (transform.position.y - lastPosition)*direction;
            lastPosition = transform.position.y;
        }
        else
        {
            distanceMoved += (transform.position.x - lastPosition)*direction;
            lastPosition = transform.position.x;
        }
        if (distanceMoved >= distance)
        {
            direction *= -1;
            StartMovement();
        }
    }

    void StartMovement(){
        if (vertical)
            {
                m_rigidBody.linearVelocityY = moveSpeed * direction;
                m_rigidBody.linearVelocityX = 0;
            }
            else
            {
                m_rigidBody.linearVelocityY = 0;
                m_rigidBody.linearVelocityX = moveSpeed * direction;
            }
            distanceMoved = 0;
    }

    void OnDrawGizmosSelected()
    {
        if (isRunning == false)
        {
            initialPosition = transform.position;
        }
        
        if (vertical)
        {
            Gizmos.DrawLine(initialPosition, initialPosition + Vector3.up* distance);
        }
        else
        {
            Gizmos.DrawLine(initialPosition, initialPosition + Vector3.right* distance);
        }
        
    }
}
