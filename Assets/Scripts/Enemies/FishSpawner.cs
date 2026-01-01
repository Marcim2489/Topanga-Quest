using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField]private BeaterFish fish;
    [SerializeField]private float spawnCooldown = 1.5f;
    [SerializeField]private float fishSwimCooldown = 1.5f;
    [SerializeField]private float startUp = 0;
    [SerializeField]private bool faceLeft;
    [SerializeField]private float fishLifeTime = 10;
    private bool canSpawn;
    private float timer;

    void Start()
    {
        if (startUp <= 0)
        {
            canSpawn = true;
            timer = spawnCooldown;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (canSpawn == false)
        {
            if (timer >= startUp)
            {
                canSpawn = true;
                timer = spawnCooldown;
            }
            else
            {
                return;
            }
        }
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
}
