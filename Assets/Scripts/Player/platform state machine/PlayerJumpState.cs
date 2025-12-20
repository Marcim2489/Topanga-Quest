using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private float timer;
    public override void EnterState(PlayerStateManager player)
    {
        player.m_animator.Play("PlayerJump");
        player.m_rigidBody.linearVelocityY = player.jump;
        player.jumpPressed = false;
        timer = 0;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.Move();
        timer+=Time.deltaTime;
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
        else
        {
            if (player.m_rigidBody.linearVelocityY < 0 || (player.jumpInput.IsPressed() == false && timer >= player.minimalJumpTime))
            {
                player.ChangeState(player.fallState);
                return;
            }
        }
    }

    public override void ExitState(PlayerStateManager player)
    {
        timer = 0;
    }
}
