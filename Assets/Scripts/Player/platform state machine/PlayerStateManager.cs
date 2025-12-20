using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : Player
{
    PlayerBaseState currentState;
    public PlayerIdleState idleState = new PlayerIdleState();
    public PlayerWalkState walkState = new PlayerWalkState();
    public PlayerJumpState jumpState = new PlayerJumpState();
    public PlayerFallState fallState = new PlayerFallState();
    public PlayerDeathState deathState = new PlayerDeathState();

    public int jump = 10;
    public InputAction moveInput;
    public InputAction jumpInput;
    public float maxFallSpeed = 200;
    public Vector2 floorRayCastSize;
    public float floorRaycastDistance;
    public LayerMask floorRaycastLayer;

    void Start()
    {
        ChangeState(idleState);
        jumpInput.Enable();
        moveInput.Enable();
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(PlayerBaseState inputState)
    {
        if (inputState == currentState)
        {
            return;
        }
        if (currentState != null)
        {
            currentState.ExitState(this);
        }
        currentState = inputState;
        currentState.EnterState(this);
    }
    public void Move()
    {
        float direction = moveInput.ReadValue<float>();
        if (direction > 0)
        {
            direction = 1;
        }else if (direction < 0)
        {
            direction = -1;
        }

        m_rigidBody.linearVelocityX = moveSpeed*direction*Time.deltaTime;
        if (m_rigidBody.linearVelocityX > 0)
        {
            m_spriteRenderer.flipX = false;
        }else if(m_rigidBody.linearVelocityX < 0)
        {
            m_spriteRenderer.flipX = true;
        }
    }
    public override void TakeDamage()
    {
        ChangeState(deathState);
    }

    public bool IsGrounded()
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
