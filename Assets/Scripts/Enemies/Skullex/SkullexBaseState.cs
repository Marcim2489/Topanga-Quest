using UnityEngine;

public abstract class SkullexBaseState
{
    public abstract void EnterState(Skullex boss);
    public abstract void UpdateState(Skullex boss);
    public abstract void ExitState(Skullex boss);
}
