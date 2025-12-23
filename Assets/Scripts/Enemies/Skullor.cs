using UnityEditor;
using UnityEngine;

public class Skullor : Enemy
{
    [SerializeField]private float detectorRadius;
    [SerializeField]private float explosionTime = 1;
    [SerializeField]private LayerMask detectorsLayerMask;
    [SerializeField]private float movesSpeed = 2;
    [SerializeField]private Player player;
    [SerializeField]private ParticleSystem particles;
    private bool following;
    private bool exploding;
    private float timer;
    private bool playerDead;

    public override void Start()
    {
        base.Start();
        if (player == null)
        {
            player = FindAnyObjectByType<Player>();
        }
        player.died+=PlayerDied;
    }

    void Update()
    {
        if (exploding)
        {
            m_rigidBody.linearVelocity = Vector3.zero;
            return;
        }

        if (Physics2D.CircleCast(transform.position, detectorRadius, Vector2.right, 0, detectorsLayerMask) && following == false)
        {
            following = true;
            particles.gameObject.SetActive(true);
        }
        if (following)
        {
            Follow();
        }
    }

     private void Follow()
    {
        timer+=Time.deltaTime;
        if (timer >= explosionTime)
        {
            Explode();
        }
        if (playerDead)
        {
            m_rigidBody.linearVelocity = Vector3.zero;
            return;
        }
        m_rigidBody.linearVelocity = movesSpeed * (player.transform.position+Vector3.up*0.0625f-transform.position).normalized;
        if (m_rigidBody.linearVelocity.x > 0)
        {
            transform.eulerAngles =new Vector3(0,180,0);
        }else if (m_rigidBody.linearVelocity.x < 0)
        {
            transform.eulerAngles =new Vector3(0,0,0);
        }
    }
    private void Explode()
    {
        hitbox.takesDamage = false;
        exploding = true;
        m_animator.SetTrigger("Explode");
        particles.Stop();
        m_rigidBody.linearVelocity = Vector3.zero;
    }

    public override void TakeDamage()
    {
        // base.TakeDamage();
        Explode();
    }

    private void PlayerDied()
    {
        playerDead = true;
    }
    private void OnDrawGizmosSelected() {
        Handles.DrawWireDisc(transform.position,Vector3.forward,detectorRadius);
    }
}
