using UnityEngine;

public class ShooterSpawner : DragonSpawner
{
    [SerializeField]private float startUp = 0.5f;
    [SerializeField]private float jumpForce = 3;

    public override void Spawn()
    {
        if (dragon is ShooterDragon)
        {
            ShooterDragon d = (ShooterDragon)Instantiate(dragon, transform.position,transform.rotation);
            d.jumpForce = jumpForce;
            d.startUp = startUp;
            d.moveSpeed = speed;
        }
        else
        {
            Instantiate(dragon, transform.position,transform.rotation);
        }
        Destroy(gameObject);
    }
}
