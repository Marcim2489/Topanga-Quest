using UnityEngine;

public class SkullexStartUp : SkullexBaseState
{
    public override void EnterState(Skullex boss)
    {
        boss.MoveDownward();
    }

    public override void UpdateState(Skullex boss)
    {
        if (boss.IsHittingFloor())
        {
            boss.Stop();
            boss.ChangeState(boss.shootingState);
        }
    }

    public override void ExitState(Skullex boss)
    {
        
    }
}
