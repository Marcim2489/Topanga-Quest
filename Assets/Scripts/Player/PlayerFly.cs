using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFly : Player
{
    [SerializeField] private InputAction flyInput;
    private float flyDirection;
    private bool dead;

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
        flyDirection = flyInput.ReadValue<float>();
        if (flyDirection > 0)
        {
            flyDirection = 1;
        } else if (flyDirection < 0)
        {
            flyDirection = -1;
        }
        m_rigidBody.linearVelocityY = flyDirection * moveSpeed * Time.deltaTime;
        m_animator.SetInteger("Direction", (int)flyDirection);
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
        m_rigidBody.gravityScale = 1;
    }
}
