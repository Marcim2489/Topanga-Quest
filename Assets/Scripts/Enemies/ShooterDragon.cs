using UnityEngine;
using UnityEditor;

public class ShooterDragon : Enemy
{
    [SerializeField]private float startUp = 1;
    [SerializeField]private DragonProjectile projectile;
    [SerializeField]private Vector2 shootPoint;
    [SerializeField]private Player player;
    [SerializeField]private bool facingLeft=true;
    private bool hasShot;
    private float timer;

    public override void Start()
    {
        base.Start();
        m_sprite.flipX = facingLeft;
        if (facingLeft == false)
        {
            shootPoint.x *= -1;
        }
        if (startUp <= 0)
        {
            Shoot();
        }
        if(player == null)
        {
            player = FindAnyObjectByType<Player>();
        }
    }

    void Update()
    {
        if (hasShot)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer >= startUp)
        {
            ShootAnimation();
        }
    }
    void ShootAnimation()
    {
        m_animator.SetTrigger("Shoot");
        hasShot = true;
    }
    public void Shoot()
    {
        DragonProjectile p = Instantiate(projectile,transform.position +(Vector3)shootPoint,transform.rotation);
        p.player = player;
        m_rigidBody.gravityScale = 1;
    }

    void OnDrawGizmosSelected()
    {
        Handles.DrawWireDisc(transform.position +(Vector3)shootPoint,Vector3.forward,0.1f);
    }
}
