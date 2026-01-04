using UnityEngine;

public class TopangaSpawner : MonoBehaviour
{
    [SerializeField]float minSpawnTimer = 0.8f;
    [SerializeField]float maxSpawnTimer = 1.5f;
    [SerializeField]TopangaRun topangaRun;
    [SerializeField]TopangaBubble topangaBubble;
    [SerializeField]TopangaFly topangaFly;
    float waitTime;
    float timer;
    int lastDice;
    int repetitions;
    void Start()
    {
        SpawnTopanga();
    }

    void Update()
    {
        timer+=Time.deltaTime;
        if (timer < waitTime)
        {
            return;
        }
        SpawnTopanga();
    }

    void ResetTimer()
    {
        timer = 0;
        waitTime = Random.Range(minSpawnTimer,maxSpawnTimer);
    }

    void SpawnTopanga()
    {
        int type = Random.Range(1,4);
        if (type == lastDice)
        {
            repetitions++;
            if (repetitions >= 2)
            {
                while (type == lastDice)
                {
                    type = Random.Range(1,4);
                }
            }
        }
        if (type != lastDice)
        {
            repetitions=0;
        }
        lastDice = type;
        switch (type)
        {
            case 1:
                Instantiate(topangaRun,transform.position,transform.rotation);
                break;
            case 2:
                Instantiate(topangaBubble,transform.position,transform.rotation);
                break;
            case 3:
                Instantiate(topangaFly,transform.position,transform.rotation);
                break;
            default:
                Instantiate(topangaRun,transform.position,transform.rotation);
                break;
        }
        ResetTimer();
    }
}
