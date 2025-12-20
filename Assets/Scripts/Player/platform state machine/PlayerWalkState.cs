using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.m_animator.Play("PlayerWalk");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.Move();
        if (player.m_rigidBody.linearVelocityX == 0)
        {
            player.ChangeState(player.idleState);
            return;
        }
        if (player.IsGrounded() == false)
        {
            player.ChangeState(player.fallState);
            return;
        }
        if (player.jumpPressed)
        {
            player.ChangeState(player.jumpState);
            return;
        }
        
        
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }
}
