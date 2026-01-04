using UnityEditor;
using UnityEngine;

public class SkullexDeathState : SkullexBaseState
{
    float timer;
    public override void EnterState(Skullex boss)
    {
        boss.DeathAnimation();
        timer = 0;
        boss.musicPlayer.Stop();

    }

    public override void UpdateState(Skullex boss)
    {
        timer+=Time.deltaTime;
        if (timer < 0.5)
        {
            return;
        }
        boss.Vanish();
    }

    public override void ExitState(Skullex boss)
    {
        
    }
}
