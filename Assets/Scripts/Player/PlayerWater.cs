using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class PlayerWater : Player
{
    [SerializeField] private int jump = 10;
    [SerializeField] private InputAction moveInput;
    [SerializeField] private InputAction jumpInput;
    [SerializeField] private float maxFallSpeed = 200;
    [SerializeField] private ParticleSystem bubbleParticle;
    private bool dead;
    [SerializeField] private AudioResource jumpSFX;

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
        m_rigidBody.linearVelocityX = moveSpeed*direction;
        
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
            PlayAudio(jumpSFX,0.7f);
        }
        
        if(m_rigidBody.linearVelocityY < -maxFallSpeed)
        {
            m_rigidBody.linearVelocityY = -maxFallSpeed;
        }
    }

    public override void TakeDamage()
    {
        base.TakeDamage();
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
        PlayAudio(deathSFX,1);
        dead = true;
    }
}
