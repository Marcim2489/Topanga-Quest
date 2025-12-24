using UnityEngine;

public class DragonSpawner : MonoBehaviour
{
    public Enemy dragon;
    [SerializeField]protected float speed = 3;

    public virtual void Spawn()
    {
        if (dragon is KillerDragon)
        {
            KillerDragon d = (KillerDragon)Instantiate(dragon, transform.position,transform.rotation);
            d.moveSpeed = speed;
        }
        else
        {
            Instantiate(dragon, transform.position,transform.rotation);
        }
        Destroy(gameObject);
    }
}
