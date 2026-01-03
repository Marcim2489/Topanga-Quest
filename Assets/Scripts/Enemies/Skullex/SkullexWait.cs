using UnityEngine;

public class SkullexWait : SkullexBaseState
{
    float timer;
    public override void EnterState(Skullex boss)
    {
        timer = 0;
    }

    public override void UpdateState(Skullex boss)
    {
        if (boss.active == false)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            boss.ChangeState(boss.startUpState);
        }
    }

    public override void ExitState(Skullex boss)
    {
        
    }
}
