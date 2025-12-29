using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFly : Player
{
    [SerializeField] private InputAction flyInput;
    private Vector2 flyDirection;

    public override void Start()
    {
        base.Start();
        flyInput.Enable();
    }

    void Update()
    {
        if (flyInput.enabled == false)
        {
            return;
        }
        if (flyInput.IsPressed() == false && flyInput.WasReleasedThisFrame() == false)
        {
            return;
        }
        flyDirection = flyInput.ReadValue<Vector2>();
        m_rigidBody.linearVelocity = flyDirection.normalized * moveSpeed;
        float dir = flyDirection.y*10;
        m_animator.SetInteger("Direction", (int)dir);
    }

    public override void TakeDamage()
    {
        base.TakeDamage();
        m_animator.SetTrigger("Death");
        flyInput.Disable();
        if (m_rigidBody.linearVelocityY > 0)
        {
            m_rigidBody.linearVelocityY = 0;
        }
        m_rigidBody.linearVelocityX = 0;
        m_rigidBody.gravityScale = 1;
    }
}
