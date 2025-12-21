using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWater : Player
{
    [SerializeField] private int jump = 10;
    [SerializeField] private InputAction moveInput;
    [SerializeField] private InputAction jumpInput;
    [SerializeField] private float maxFallSpeed = 200;
    [SerializeField] private ParticleSystem bubbleParticle;
    private bool dead;
    public override void Start()
    {
        base.Start();
        moveInput.Enable();
        jumpInput.Enable();
    }

    void Update()
    {
        if (dead)
        {
            if(m_rigidBody.linearVelocityY < -maxFallSpeed)
        {
            m_rigidBody.linearVelocityY = -maxFallSpeed;
        }
            return;
        }
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

    public override void TakeDamage()
    {
        m_animator.SetTrigger("death");
        Instantiate(bubbleParticle,transform.position,transform.rotation);
        maxFallSpeed = 1;
        m_rigidBody.linearVelocityX = 0;
        if (m_rigidBody.linearVelocityY > 0)
        {
            m_rigidBody.linearVelocityY = 0;
        }
        jumpInput.Disable();
        moveInput.Disable();
        dead = true;
    }
}
