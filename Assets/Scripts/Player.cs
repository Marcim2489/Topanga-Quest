using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 60;
    [SerializeField] private int jump = 10;
    [SerializeField] private InputAction moveInput;
    [SerializeField] private InputAction jumpInput;
    private Rigidbody2D m_rigidBody;
    private Animator m_animator;
    private bool grounded;

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        moveInput.Enable();
        jumpInput.Enable();
    }

    void Update()
    {
        float direction = moveInput.ReadValue<float>();
        m_rigidBody.linearVelocityX = moveSpeed*direction*Time.deltaTime;
        if (jumpInput.WasPressedThisFrame() && grounded)
        {
            m_rigidBody.linearVelocityY = 10;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if ((Vector3)collision.GetContact(0).normal == Vector3.up)
            {
                grounded = true;
            }
            
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
           /*  if (collision.GetContact(0).normal == Vector2.up)
            {
                grounded = false;
            } */
            grounded = false;
        }
    }
}
