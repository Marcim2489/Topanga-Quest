using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;

public class SkullexShooting : SkullexBaseState
{
    float timer;
    int shots;
    bool canShoot;
    public override void EnterState(Skullex boss)
    {
        boss.BecomeVulnerable();
        timer = 0;
        shots = 0;
        canShoot = false;
    }

    public override void UpdateState(Skullex boss)
    {
        timer+= Time.deltaTime;
        if (canShoot == false)
        {
            if (timer<=boss.shotStartUp)
            {
                return;
            }
            else
            {
                boss.Shoot();
                timer = 0;
                shots++;
                canShoot = true;
            }
        }
        
        if (timer < boss.shotCooldown)
        {
            return;
        }

        if (shots < boss.shotsPerAttack)
        {
            boss.Shoot();
            timer = 0;
            shots++;
            return;
        }
        if (timer < boss.shotCooldown*1.7f)
        {
            return;
        }
        
        boss.ChangeState(boss.moveState);
        
    }

    public override void ExitState(Skullex boss)
    {
        timer = 0;
        shots = 0;
        canShoot = false;
    }
}
