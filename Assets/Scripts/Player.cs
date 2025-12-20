using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 400;
    [SerializeField] private int jump = 10;
    [SerializeField] private InputAction moveInput;
    [SerializeField] private InputAction jumpInput;
    [SerializeField] private float maxFallSpeed = 200;
    [SerializeField] private Vector2 floorRayCastSize;
    [SerializeField] private float floorRaycastDistance;
    [SerializeField] private float floorRayCastOffsetX;
    [SerializeField] private LayerMask floorRaycastLayer;
    private Rigidbody2D m_rigidBody;
    private Animator m_animator;
    private SpriteRenderer m_spriteRenderer;
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
        moveInput.Enable();
        jumpInput.Enable();
    }

    void Update()
    {
        float direction = moveInput.ReadValue<float>();
        m_animator.SetInteger("direction",(int)direction);
        m_rigidBody.linearVelocityX = moveSpeed*direction*Time.deltaTime;
        if (m_rigidBody.linearVelocityX > 0)
        {
            m_spriteRenderer.flipX = false;
        }else if(m_rigidBody.linearVelocityX < 0)
        {
            m_spriteRenderer.flipX = true;
        }
        bool grounded = IsGrounded();
        m_animator.SetBool("grounded", grounded);
        if (jumpInput.WasPressedThisFrame() && grounded)
        {
            m_rigidBody.linearVelocityY = jump;
        }
        
        if(jumpInput.WasReleasedThisFrame() && grounded == false && m_rigidBody.linearVelocityY >0)
        {
            m_rigidBody.linearVelocityY = 0;
        }
        if(m_rigidBody.linearVelocityY < -maxFallSpeed)
        {
            m_rigidBody.linearVelocityY = -maxFallSpeed;
        }
    }

    private bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position+floorRayCastOffsetX*transform.right, floorRayCastSize, 0, -transform.up, floorRaycastDistance, floorRaycastLayer))
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
        Gizmos.DrawWireCube(transform.position - transform.up*floorRaycastDistance+floorRayCastOffsetX*transform.right,floorRayCastSize);
    }
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("ground"))
    //     {
    //         if ((Vector3)collision.GetContact(0).normal == Vector3.up)
    //         {
    //             grounded = true;
    //         }

    //     }
    // }

    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("ground"))
    //     {
    //        /*  if (collision.GetContact(0).normal == Vector2.up)
    //         {
    //             grounded = false;
    //         } */
    //         grounded = false;
    //     }
    // }
}
