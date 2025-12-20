using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.m_animator.Play("PlayerFall");
        if (player.m_rigidBody.linearVelocityY >= 0)
        {
            player.m_rigidBody.linearVelocityY = 0;
        }
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
        player.Move();
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }
}
