using UnityEngine;

public class Skullex : Enemy
{
    [SerializeField]CannonBall projectile;
    [SerializeField]float projectileSpeed = 6;
    [SerializeField]float shotCooldown = 1;
    [SerializeField]int shotsPerAttack = 3;
    [SerializeField]float speed = 8;
    [SerializeField]Vector2 rayCastSize;
    [SerializeField]float rayCastOffset;
    [SerializeField]LayerMask rayCastLayer;

    int phase = 1;
    int shots= 0;
    float timer;
    bool moving;

    void FixedUpdate()
    {
        if (moving)
        {
            if (HitWall())
            {
                Stop();
            }
            else
            {
                return;
            }
        }
        timer += Time.deltaTime;
        if (timer >= shotCooldown)
        {
            if (shots < shotsPerAttack)
            {
                Shoot();
            }
            else
            {
                MoveForward();
            }
            
            
        }
    }

    void Shoot()
    {
        CannonBall p = Instantiate(projectile, transform.position, transform.rotation);
        p.speed = projectileSpeed;
        p.transform.Rotate(new Vector3(0,0,-90));
        p.Shoot();
        timer = 0;
        shots++;
    }

    void MoveForward()
    {
        timer = 0;
        shots = 0;
        moving = true;
        m_rigidBody.linearVelocity = speed * transform.right;
    }

    void Stop()
    {
        m_rigidBody.linearVelocity= Vector2.zero;
        transform.Rotate(new Vector3(0,180,0));
        moving = false;
    }

    public bool HitWall()
    {
        if (Physics2D.BoxCast(transform.position, rayCastSize, 0, transform.right, rayCastOffset, rayCastLayer))
        {
            
            return true;
        }else
        {
            return false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position + rayCastOffset*transform.right,rayCastSize);
    }
}
