using UnityEngine;

public class Bang : Enemy
{
    [SerializeField]private Vector2 floorRayCastSize;
    [SerializeField]private float floorRaycastDistance;
    [SerializeField]private LayerMask floorRaycastLayer;
    [SerializeField]private float jump = 6;
    [SerializeField]private float horizontalForce = 3;
    private bool goingLeft = true;

    void Update()
    {
        if (IsGrounded())
            {
                Jump();
            }
    }

    void Jump()
    {
        m_rigidBody.linearVelocityY = jump;
        if (goingLeft)
        {
            m_rigidBody.linearVelocityX = horizontalForce;
            goingLeft = false;
        }
        else
        {
            m_rigidBody.linearVelocityX = -horizontalForce;
            goingLeft = true;
        }
        m_animator.SetBool("GoingLeft", goingLeft);
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
