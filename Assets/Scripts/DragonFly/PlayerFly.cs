using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFly : MonoBehaviour
{
    [SerializeField] private float flySpeed = 50;
    [SerializeField] private InputAction flyInput;
    private Rigidbody2D m_rigidBody;
    private Animator m_animator;
    private float flyDirection;

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        flyInput.Enable();
    }

    void Update()
    {
        if (flyInput.IsPressed() == false && flyInput.WasReleasedThisFrame() == false)
        {
            return;
        }
        flyDirection = flyInput.ReadValue<float>();
        if (flyDirection > 0)
        {
            flyDirection = 1;
        } else if (flyDirection < 0)
        {
            flyDirection = -1;
        }
        m_rigidBody.linearVelocityY = flyDirection * flySpeed * Time.deltaTime;
        m_animator.SetInteger("Direction", (int)flyDirection);
    }

}
