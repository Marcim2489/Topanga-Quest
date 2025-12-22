using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]private float shotCooldown = 1;
    [SerializeField]private EnemyHitbox projectile;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= shotCooldown)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            timer = 0;
        }
    }
}
