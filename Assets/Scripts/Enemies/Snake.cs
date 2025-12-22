using UnityEngine;

public class Snake : Enemy
{
    [SerializeField] private Vector2 frontCastSize;
    [SerializeField] private float frontCastDistance;
    [SerializeField] private float frontCastYOffset;
    [SerializeField] private Vector2 bottomCastSize;
    [SerializeField] private float bottomCastDistance;
    [SerializeField] private float bottomCastYOffset;
    [SerializeField] private LayerMask castLayer;
    [SerializeField] private float movesSpeed = 100;
    private int facingDirection = 1;
    
    private void Update()
    {
        if (Physics2D.BoxCast(transform.position+ Vector3.up*frontCastYOffset, frontCastSize, 0, transform.right * facingDirection, frontCastDistance, castLayer)||
        Physics2D.BoxCast(transform.position+Vector3.up*bottomCastYOffset, bottomCastSize, 0, transform.right * facingDirection, bottomCastDistance, castLayer))
        {
            Flip();
        }
        m_rigidBody.linearVelocityX = movesSpeed*facingDirection*Time.deltaTime;
    }

    private void Flip()
    {
        facingDirection *= -1;
        m_sprite.flipX = !m_sprite.flipX;
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawWireCube(transform.position+ Vector3.up*frontCastYOffset + transform.right*frontCastDistance*facingDirection,frontCastSize);
    //     Gizmos.DrawWireCube(transform.position+Vector3.up*bottomCastYOffset + transform.right*bottomCastDistance*facingDirection,bottomCastSize);
    // }
}
