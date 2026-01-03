using UnityEngine;

public class SkullexMove : SkullexBaseState
{
    public override void EnterState(Skullex boss)
    {
        boss.MoveForward();
        boss.BecomeInvulnerable();
    }

    public override void UpdateState(Skullex boss)
    {
        if (boss.IsHittingWall())
        {
            boss.Stop();
            boss.TurnAround();
            boss.ChangeState(boss.shootingState);
        }
    }

    public override void ExitState(Skullex boss)
    {
        boss.BecomeVulnerable();
    }
}
