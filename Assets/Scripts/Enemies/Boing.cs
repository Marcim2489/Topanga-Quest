using UnityEngine;

public class Boing : Enemy
{
    [SerializeField]private Vector2 floorRayCastSize;
    [SerializeField]private float floorRaycastDistance;
    [SerializeField]private LayerMask floorRaycastLayer;
    [SerializeField]private float jump = 8;

    void Update()
    {
        if (m_rigidBody.linearVelocityY <= 0)
        {
            m_animator.SetBool("Falling", true);
            
        }
        if (IsGrounded())
            {
                Jump();
            }
    }

    void Jump()
    {
        m_rigidBody.linearVelocityY = jump;
        m_animator.SetBool("Falling", false);
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up*floorRaycastDistance,floorRayCastSize);
    }
}
