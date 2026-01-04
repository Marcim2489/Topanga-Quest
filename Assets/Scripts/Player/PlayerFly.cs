using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class PlayerFly : Player
{
    [SerializeField] private InputAction flyInput;
    private Vector2 flyDirection;
    private bool finishedLevel;

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
        Debug.Log(flyDirection);
        m_rigidBody.linearVelocity = flyDirection.normalized * moveSpeed;
        float dir = flyDirection.y*10;
        m_animator.SetInteger("Direction", (int)dir);
    }

    public override void TakeDamage()
    {
        if (finishedLevel)
        {
            return;
        }
        base.TakeDamage();
        m_animator.SetTrigger("Death");
        flyInput.Disable();
        if (m_rigidBody.linearVelocityY > 0)
        {
            m_rigidBody.linearVelocityY = 0;
        }
        m_rigidBody.linearVelocityX = 0;
        m_rigidBody.gravityScale = 1;
        foreach(CircleCollider2D circle in GetComponents<CircleCollider2D>())
        {
            Destroy(circle);
        };
    }

    public void EndLevel()
    {
        m_rigidBody.linearVelocityY = 0;
        m_rigidBody.linearVelocityX = moveSpeed*1.5f;
        flyInput.Disable();
        finishedLevel = true;
    }
}
