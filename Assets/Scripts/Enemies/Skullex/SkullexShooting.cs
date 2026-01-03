using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;

public class SkullexShooting : SkullexBaseState
{
    float timer;
    int shots;
    public override void EnterState(Skullex boss)
    {
        boss.BecomeVulnerable();
        timer = 0;
        shots = 0;
    }

    public override void UpdateState(Skullex boss)
    {
        timer+= Time.deltaTime;
        if (timer < boss.shotCooldown)
        {
            return;
        }

        if (shots < boss.shotsPerAttack)
        {
            boss.Shoot();
            timer = 0;
            shots++;
        }
        else
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
