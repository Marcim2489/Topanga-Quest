using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField]private BeaterFish fish;
    [SerializeField]private float spawnCooldown = 1.5f;
    [SerializeField]private float fishSwimCooldown = 1.5f;
    [SerializeField]private FishSpawnerTrigger trigger;
    [SerializeField]private bool faceLeft;
    [SerializeField]private float fishLifeTime = 10;
    private bool canSpawn;
    private float timer;

    void Start()
    {
        trigger.playerEntered += PlayerEntered;
        trigger.playerExited += PlayerExited;
    }

    void Update()
    {
        if (canSpawn == false)
        {
            return;
        }
        timer += Time.deltaTime;
        
        if (timer >= spawnCooldown)
        {
            SpawnFish();
        }
    }

    void SpawnFish()
    {
        BeaterFish f =Instantiate(fish, transform.position,transform.rotation);
        if (faceLeft)
        {
            f.SetDirectionAndSwim(-1);
        }
        else
        {
            f.SetDirectionAndSwim(1);
        }
        f.swimCooldown = fishSwimCooldown;
        Destroy(f.gameObject,fishLifeTime);
        timer = 0;
    }

    void PlayerEntered()
    {
        canSpawn = true;
        timer = 0;
    }

    void PlayerExited()
    {
        canSpawn = false;
        timer = 0;
    }
}
