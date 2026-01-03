using UnityEngine;

public class SkullexBetweenPhase : SkullexBaseState
{
    bool hitCeiling;
    int shots;
    float timer;
    bool right;
    public override void EnterState(Skullex boss)
    {
        timer = 0;
        hitCeiling = false;
        shots = 0;
        boss.BecomeInvulnerable();
        boss.MoveForward();
    }

    public override void UpdateState(Skullex boss)
    {
        if (hitCeiling)
        {
            timer+= Time.deltaTime;
            if (shots >= 6)
            {
                if (timer >= 2)
                {
                    boss.ChangeState(boss.startUpState);
                }
                return;
            }
            if (timer >= 0.2f)
            {
                if (right)
                {
                    boss.ShootDownwards(boss.leftPosition + Vector3.right*1.25f*shots - Vector3.right*0.3125f);
                }
                else
                {
                    boss.ShootDownwards(boss.rightPosition - Vector3.right*1.25f*shots + Vector3.right*0.3125f);
                }
                
                timer = 0;
                shots ++;
            }
            return;
        }
        boss.AccelerateUpwards(0.1f);
        if (boss.IsHittingCeiling())
        {
            hitCeiling = true;
            boss.Stop();
            boss.DecidePosition();
            if (boss.transform.position == boss.rightPosition)
            {
                right = true;
            }
            else
            {
                right = false;
            }
        }
    }

    public override void ExitState(Skullex boss)
    {

    }
}
