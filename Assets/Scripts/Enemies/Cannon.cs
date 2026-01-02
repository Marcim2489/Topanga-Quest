using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]private float shotCooldown = 1;
    [SerializeField]private float startUp = 0;
    [SerializeField]private CannonBall projectile;
    [SerializeField]private float projectileSpeed = 4;
    [SerializeField]private float projectileLifeTime = 5;
    [SerializeField]private AudioSource audioPlayer;
    private float timer;
    private bool canShoot;

    void Start()
    {
        if (startUp <= 0)
        {
            canShoot = true;
            timer = shotCooldown;
        }
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (canShoot == false)
        {
            if (timer >= startUp)
            {
                canShoot = true;
                timer = shotCooldown;
            }
            else
            {
                return;
            }
        }
        
        if(timer >= shotCooldown)
        {
            CannonBall c =Instantiate(projectile, transform.position, transform.rotation);
            c.speed = projectileSpeed;
            c.lifeTime = projectileLifeTime;
            c.Shoot();
            audioPlayer.Play();
            timer = 0;
        }
    }
}
