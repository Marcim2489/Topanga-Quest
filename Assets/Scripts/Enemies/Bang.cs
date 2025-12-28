using UnityEngine;

public class Bang : Enemy
{
    [SerializeField]private Vector2 floorRayCastSize;
    [SerializeField]private float floorRaycastDistance;
    [SerializeField]private LayerMask floorRaycastLayer;
    [SerializeField]private float jump = 6;
    [SerializeField]private float horizontalForce = 3;
    private int direction = -1;

    void FixedUpdate()
    {
        if (m_rigidBody.linearVelocityY > 0)
        {
            return;
        }
        if (IsGrounded())
            {
                Jump();
            }
    }

    void Jump()
    {
        
        direction *= -1;
        m_rigidBody.linearVelocityY = jump;
        
        m_rigidBody.linearVelocityX = horizontalForce * direction;
        
        m_animator.SetInteger("Direction", direction);
    }
    private bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, floorRayCastSize, 0, -transform.up, floorRaycastDistance, floorRaycastLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position - transform.up*floorRaycastDistance,floorRayCastSize);
    }
}
