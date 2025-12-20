using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWater : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 60;
    [SerializeField] private int jump = 10;
    [SerializeField] private InputAction moveInput;
    [SerializeField] private InputAction jumpInput;
    [SerializeField] private float maxFallSpeed = 200;
    private Rigidbody2D m_rigidBody;
    private Animator m_animator;
    [SerializeField] private SpriteRenderer m_spriteRenderer;

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
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
