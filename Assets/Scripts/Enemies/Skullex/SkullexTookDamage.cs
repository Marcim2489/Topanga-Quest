using System.Threading;
using UnityEngine;

public class SkullexTookDamage : SkullexBaseState
{
    float timer; 
    public override void EnterState(Skullex boss)
    {
        timer = 0;
        boss.Stop();
        boss.BecomeInvulnerable();
    }

    public override void UpdateState(Skullex boss)
    {
        timer += Time.deltaTime;
        if (timer>= 0.5f)
        {
            switch (boss.phase)
            {
                case 1:
                    boss.ChangeState(boss.moveState1);
                    break;
                case 2:
                    boss.ChangeState(boss.moveState2);
                    break;
                case 3:
                    boss.ChangeState(boss.moveState3);
                    break;
            }
        }
    }

    public override void ExitState(Skullex boss)
    {

    }
}
