using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    private float timer;

    public override void EnterState(PlayerStateManager player)
    {
        player.m_animator.Play("PlayerFall");
        if (player.m_rigidBody.linearVelocityY >= 0)
        {
            player.m_rigidBody.linearVelocityY = 0;
        }
        timer = 0;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.Move();
        player.MaxFallSpeed();
        timer += Time.deltaTime;
        if (player.IsGrounded() || timer <= player.coyoteTime)
        {
            if (player.jumpPressed)
            {
                player.ChangeState(player.jumpState);
                return;
            }
        }
        if (player.IsGrounded())
        {
            if (player.m_rigidBody.linearVelocityX != 0)
            {
                player.ChangeState(player.walkState);
                return;
            } else
            {
                player.ChangeState(player.idleState);
                return;
            }
        }
    }

    public override void ExitState(PlayerStateManager player)
    {
        timer = 0;
    }
}
