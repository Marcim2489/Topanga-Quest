using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.m_animator.Play("PlayerJump");
        player.m_rigidBody.linearVelocityY = player.jump;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.IsGrounded())
        {
            if (player.moveInput.ReadValue<float>() != 0)
            {
                player.ChangeState(player.walkState);
                return;
            } else
            {
                player.ChangeState(player.idleState);
                return;
            }
        }
        else
        {
            if (player.m_rigidBody.linearVelocityY < 0 || player.jumpInput.WasReleasedThisFrame())
            {
                player.ChangeState(player.fallState);
                return;
            }
            player.Move();
        }
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }
}
