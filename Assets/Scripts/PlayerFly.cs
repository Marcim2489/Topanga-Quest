using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFly : Player
{
    [SerializeField] private InputAction flyInput;
    private float flyDirection;

    void Start()
    {
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
        m_rigidBody.linearVelocityY = flyDirection * moveSpeed * Time.deltaTime;
        m_animator.SetInteger("Direction", (int)flyDirection);
    }

}
