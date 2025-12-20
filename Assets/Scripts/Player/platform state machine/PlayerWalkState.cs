using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.m_animator.Play("PlayerWalk");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.IsGrounded() == false)
        {
            player.ChangeState(player.fallState);
            return;
        }
        if (player.jumpInput.WasPressedThisFrame())
        {
            player.ChangeState(player.jumpState);
            return;
        }
        player.Move();
        if (player.m_rigidBody.linearVelocityX == 0)
        {
            player.ChangeState(player.idleState);
            return;
        }
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }
}
