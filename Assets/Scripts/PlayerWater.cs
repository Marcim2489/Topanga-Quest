using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWater : Player
{
    [SerializeField] private int jump = 10;
    [SerializeField] private InputAction moveInput;
    [SerializeField] private InputAction jumpInput;
    [SerializeField] private float maxFallSpeed = 200;

    void Start()
    {
        moveInput.Enable();
        jumpInput.Enable();
    }

    void Update()
    {
        float direction = moveInput.ReadValue<float>();
        m_rigidBody.linearVelocityX = moveSpeed*direction*Time.deltaTime;
        
        if (m_rigidBody.linearVelocityX > 0)
        {
            m_spriteRenderer.flipX = false;
        }else if(m_rigidBody.linearVelocityX < 0)
        {
            m_spriteRenderer.flipX = true;
        }

        if (jumpInput.WasPressedThisFrame())
        {
            m_rigidBody.linearVelocityY = jump;
            m_animator.SetTrigger("jump");
        }
        
        if(m_rigidBody.linearVelocityY < -maxFallSpeed)
        {
            m_rigidBody.linearVelocityY = -maxFallSpeed;
        }
    }
}
