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
    [SerializeField] private float jumpBuffer = 0.2f;
    public float minimalJumpTime = 0.2f;
    public float coyoteTime = 0.1f;
    public float maxFallSpeed = 200;
    public Vector2 floorRayCastSize;
    public float floorRaycastDistance;
    public LayerMask floorRaycastLayer;
    [SerializeField] private PlayerHitbox hitbox;
    [HideInInspector]public bool jumpPressed;
    private float jumpBufferTimer;

    void Start()
    {
        ChangeState(idleState);
        jumpInput.Enable();
        moveInput.Enable();
        hitbox.landedHit += Pulinho;
        hitbox.tookHit += TakeDamage;
    }

    void Update()
    {
        if (jumpPressed)
        {
            jumpBufferTimer -= Time.deltaTime;
            if (jumpBufferTimer <= 0)
            {
                jumpPressed = false;
            }
        }
        if (jumpInput.WasPressedThisFrame())
        {
            jumpBufferTimer = jumpBuffer;
            jumpPressed = true;
        }
        
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
        Debug.Log(direction);
        if (direction > 0)
        {
            direction = 1;
        }else if (direction < 0)
        {
            direction = -1;
        }
        else
        {
            m_rigidBody.linearVelocityX = 0;
            return;
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
        hitbox.gameObject.SetActive(false);
        Destroy(gameObject);
    }
    private void Pulinho()
    {
        ChangeState(jumpState);
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

    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawWireCube(transform.position - transform.up*floorRaycastDistance,floorRayCastSize);
    // }

}
