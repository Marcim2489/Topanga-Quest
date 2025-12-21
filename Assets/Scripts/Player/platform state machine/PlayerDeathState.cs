using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.m_animator.Play("PlayerDeath");
        player.m_rigidBody.linearVelocityX = 0;
        if (player.m_rigidBody.linearVelocityY > 0)
        {
            player.m_rigidBody.linearVelocityY = 0;
        }
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.MaxFallSpeed();
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }
}
