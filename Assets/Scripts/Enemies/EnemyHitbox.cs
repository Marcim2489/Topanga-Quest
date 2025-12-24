using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public event System.Action landedHit;
    public event System.Action tookHit;
    public bool takesDamage = true;

    public void LandedHit()
    {
        landedHit?.Invoke();
    }
    public void TookHit()
    {
        tookHit?.Invoke();
    }

    public virtual void Activate()
    {
    }
}