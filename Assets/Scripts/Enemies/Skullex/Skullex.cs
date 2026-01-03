using UnityEngine;

public class Skullex : Enemy
{
    public CannonBall projectile;
    [SerializeField]float projectileSpeed = 6;
    public float shotCooldown = 1;
    public int shotsPerAttack = 3;
    public float speed = 8;
    [SerializeField]Vector2 rayCastSize;
    [SerializeField]float rayCastOffset;
    [SerializeField]LayerMask rayCastLayer;
    [SerializeField]ParticleSystem particle;
    SkullexBaseState currentState;
    public SkullexShooting shootingState = new SkullexShooting();
    public SkullexTookDamage damageState = new SkullexTookDamage();
    public SkullexMovePhase1 moveState1 = new SkullexMovePhase1();
    public SkullexBetweenPhase betweenPhaseState = new SkullexBetweenPhase();
    public SkullexMovePhase2 moveState2 = new SkullexMovePhase2();
    public SkullexMovePhase3 moveState3 = new SkullexMovePhase3();

    [HideInInspector]public int phase = 1;
    public override void Start()
    {
        base.Start();
        BecomeVulnerable();
        ChangeState(shootingState);
    }
    void FixedUpdate()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(SkullexBaseState inputState)
    {
        if (inputState == currentState)
        {
            return;
        }
        if (currentState != null)
        {
            currentState.ExitState(this);
        }
        currentState = inputState;
        currentState.EnterState(this);
        }
    public override void TakeDamage()
    {
        base.TakeDamage();
        phase++;
        ChangeState(damageState);

    }
    public void Shoot()
    {
        CannonBall p = Instantiate(projectile, transform.position, transform.rotation);
        p.speed = projectileSpeed;
        p.transform.Rotate(new Vector3(0,0,-90));
        p.Shoot();
    }

    public void MoveForward()
    {
        m_rigidBody.linearVelocity = speed * transform.right;
    }

    public void Stop()
    {
        m_rigidBody.linearVelocity= Vector2.zero;
    }

    public void TurnAround()
    {
        transform.Rotate(new Vector3(0,180,0));
    }

    public bool IsHittingWall()
    {
        if (Physics2D.BoxCast(transform.position, rayCastSize, 0, transform.right, rayCastOffset, rayCastLayer))
        {
            
            return true;
        }else
        {
            return false;
        }
    }

    public void BecomeVulnerable()
    {
        // if (hitbox.takesDamage == false)
        // {
        //     return;
        // }
        particle.Stop();
        hitbox.takesDamage = true;
    }

    public void BecomeInvulnerable()
    {
        // if (hitbox.takesDamage)
        // {
        //     return;
        // }
        particle.Play();
        Debug.Log('a');
        hitbox.takesDamage = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position + rayCastOffset*transform.right,rayCastSize);
    }
}
