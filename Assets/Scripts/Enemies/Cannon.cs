using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]private float shotCooldown = 1;
    [SerializeField]private float startUp = 0;
    [SerializeField]private EnemyHitbox projectile;
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

    void Update()
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
            Instantiate(projectile, transform.position, transform.rotation);
            timer = 0;
        }
    }
}
