using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private float timer;
    private float minimalTime;

    public override void EnterState(PlayerStateManager player)
    {
        player.m_animator.Play("PlayerJump");
        player.m_rigidBody.linearVelocityY = player.jump;
        player.jumpPressed = false;
        timer = 0;
        player.canJump = false;
        if (player.enemyJumped)
        {
            player.enemyJumped = false;
            minimalTime = player.minimalJumpTime * 1.5f;
        }
        else
        {
            minimalTime = player.minimalJumpTime;
        }
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.Move();
        timer+=Time.deltaTime;
        if (player.IsGrounded()&& player.m_rigidBody.linearVelocityY<=0)
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
            if (player.m_rigidBody.linearVelocityY < 0 || (player.jumpInput.IsPressed() == false && timer >= minimalTime))
            {
                player.ChangeState(player.fallState);
                return;
            }
        }
    }

    public override void ExitState(PlayerStateManager player)
    {
        timer = 0;
        player.enemyJumped = false;
    }
}
