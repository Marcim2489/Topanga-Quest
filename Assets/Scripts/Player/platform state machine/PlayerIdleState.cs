using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.m_animator.Play("PlayerIdle");
        player.canJump = true;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.Move();
        if (player.m_rigidBody.linearVelocityX != 0)
        {
            player.ChangeState(player.walkState);
            return;
        }
        if (player.jumpPressed)
        {
            player.ChangeState(player.jumpState);
            return;
        }
        if (player.IsGrounded() == false)
        {
            player.ChangeState(player.fallState);
            return;
        }
        
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }
}
