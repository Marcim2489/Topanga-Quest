using UnityEngine;
using UnityEditor;

public class ShooterDragon : Enemy
{
    public float startUp = 0.5f;
    public float jumpForce = 3;
    public float moveSpeed = 3;
    [SerializeField]private DragonProjectile projectile;
    [SerializeField]private Vector2 shootPoint;
    [SerializeField]private Player player;
    [SerializeField]private bool facingLeft=true;
    private bool hasShot;
    private float timer;
    private bool preparingShoot;

    public override void Start()
    {
        base.Start();
        m_sprite.flipX = facingLeft;
        if (facingLeft == false)
        {
            shootPoint.x *= -1;
        }
        
        if(player == null)
        {
            player = FindAnyObjectByType<Player>();
        }
        m_rigidBody.linearVelocityX = -moveSpeed;
        if (startUp <= 0)
        {
            GoUp();
        }
    }

    void Update()
    {
        if (hasShot)
        {
            return;
        }
        if (preparingShoot)
        {
            if (m_rigidBody.linearVelocityY <= 0)
            {
                ShootAnimation();
            }
            return;
        }
        timer += Time.deltaTime;
        if (timer >= startUp)
        {
            GoUp();
        }
    }
    void GoUp()
    {
        m_rigidBody.linearVelocityY = jumpForce;
        m_rigidBody.gravityScale = 1;
        m_rigidBody.linearVelocityX = 0;
        preparingShoot = true;
    }
    void ShootAnimation()
    {
        m_animator.SetTrigger("Shoot");
        m_rigidBody.gravityScale = 0;
        m_rigidBody.linearVelocityY = 0;
    }

    public void Shoot()
    {
        m_rigidBody.gravityScale = 1;
        DragonProjectile p = Instantiate(projectile,transform.position +(Vector3)shootPoint,transform.rotation);
        p.player = player;
        hasShot = true;
    }

    void OnDrawGizmosSelected()
    {
        // Handles.DrawWireDisc(transform.position +(Vector3)shootPoint,Vector3.forward,0.1f);
    }
}
