using System.Threading;
using UnityEngine;

public class SkullexTookDamage : SkullexBaseState
{
    float timer; 
    public override void EnterState(Skullex boss)
    {
        timer = 0;
        boss.Stop();
        
    }

    public override void UpdateState(Skullex boss)
    {
        timer += Time.deltaTime;
        if (timer>= 0.2f)
        {
            boss.ChangeState(boss.betweenPhaseState);
        }
    }

    public override void ExitState(Skullex boss)
    {

    }
}
