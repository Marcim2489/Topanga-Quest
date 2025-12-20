using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.m_animator.Play("PlayerIdle");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.moveInput.ReadValue<float>() != 0)
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
