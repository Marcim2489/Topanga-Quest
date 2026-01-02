using UnityEngine;

public class SnowIntensifier : MonoBehaviour
{
    
    [SerializeField]ParticleSystem snow;
    [SerializeField]ParticleSystem snow2;
    float timer;
    bool canPlay;
    public void Trigger()
    {
        snow.Stop();
        canPlay=true;
    }

    void Update()
    {
        if(canPlay == false)
        {
            return;
        }
        timer += Time.deltaTime;
        if(timer >= 2.5f)
        {
            snow2.Play();
            canPlay = false;
            Destroy(gameObject);
        }
    }
}
