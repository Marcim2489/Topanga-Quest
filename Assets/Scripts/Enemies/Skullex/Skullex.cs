using System;
using UnityEngine;
using UnityEngine.Audio;

public class Skullex : Enemy
{
    public CannonBall projectile;
    [SerializeField]float projectileSpeed = 5;
    public float shotCooldown = 1;
    public float shotStartUp = 0.3f;
    public int shotsPerAttack = 3;
    public float speed = 6;
    [SerializeField]Vector2 rayCastSize;
    [SerializeField]float rayCastOffset;
    [SerializeField]LayerMask rayCastLayer;
    [SerializeField]Vector2 floorCastSize;
    [SerializeField]float floorCastOffset;
    [SerializeField]float ceilingCastOffset;
    public Vector3 rightPosition;
    public Vector3 leftPosition;
    SkullexBaseState currentState;
    public SkullexWait waitState = new SkullexWait();
    public SkullexStartUp startUpState = new SkullexStartUp();
    public SkullexShooting shootingState = new SkullexShooting();
    public SkullexTookDamage damageState = new SkullexTookDamage();
    public SkullexMove moveState = new SkullexMove();
    public SkullexBetweenPhase betweenPhaseState = new SkullexBetweenPhase();
    [SerializeField]SpriteRenderer aura;
    public AudioResource bossMusic;
    [HideInInspector]public bool active; 
    [HideInInspector]public int phase = 1;
    public event System.Action died;
    public override void Start()
    {
        base.Start();
        DecidePosition();
        BecomeInvulnerable();
        ChangeState(waitState);
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
        m_animator.SetTrigger("Damaged");

    }

    public override void Death()
    {
        base.Death();
        died?.Invoke();
    }

    public void Shoot()
    {
        m_animator.SetTrigger("Shoot");
    }
    public void InstantiateProjectile()
    {
        CannonBall p = Instantiate(projectile, transform.position+ Vector3.down*8*0.03125f, transform.rotation);
        p.speed = projectileSpeed;
        p.transform.Rotate(new Vector3(0,0,-90));
        p.Shoot();
    }

    public void ShootDownwards(Vector3 position)
    {
        CannonBall p = Instantiate(projectile, position, transform.rotation);
        p.speed = projectileSpeed*0.7f;
        p.transform.Rotate(new Vector3(0,0,-180));
        p.Shoot();
    }
    public void MoveForward()
    {
        m_rigidBody.linearVelocity = speed * transform.right;
        m_animator.SetBool("Moving",true);
    }
    public void AccelerateUpwards(float a)
    {
        m_rigidBody.linearVelocityY +=a;
    }
    public void MoveDownward()
    {
        m_rigidBody.linearVelocity = speed/2 * -transform.up;
    }

    public void Stop()
    {
        m_rigidBody.linearVelocity= Vector2.zero;
        m_animator.SetBool("Moving",false);
    }

    public void TurnAround()
    {
        if (transform.rotation.y == 0)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
        
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
    public bool IsHittingFloor()
    {
         if (Physics2D.BoxCast(transform.position, floorCastSize, 0, -transform.up, floorCastOffset, rayCastLayer))
        {
            
            return true;
        }else
        {
            return false;
        }
    }
    public bool IsHittingCeiling()
    {
         if (Physics2D.BoxCast(transform.position, floorCastSize, 0, transform.up, ceilingCastOffset, rayCastLayer))
        {
            
            return true;
        }else
        {
            return false;
        }
    }
    public void BecomeVulnerable()
    {
        if (hitbox.takesDamage)
        {
            return;
        }
        aura.gameObject.SetActive(false);
        hitbox.takesDamage = true;
    }

    public void BecomeInvulnerable()
    {
        if (hitbox.takesDamage==false)
        {
            return;
        }
        aura.gameObject.SetActive(true);
        hitbox.takesDamage = false;
    }
    public void DecidePosition()
    {
        switch (UnityEngine.Random.Range(1, 3))
        {
            case 1:
                transform.position = rightPosition;
                transform.eulerAngles = new Vector3(0,180,0);
                break;
            case 2:
                transform.position = leftPosition;
                transform.eulerAngles = new Vector3(0,0,0);
                break;
        }
    }
    public void Trigger()
    {
        active = true;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position + rayCastOffset*transform.right,rayCastSize);
        Gizmos.DrawWireCube(transform.position + floorCastOffset*-transform.up,floorCastSize);
        Gizmos.DrawWireCube(transform.position + ceilingCastOffset*transform.up,floorCastSize);
    }
}
