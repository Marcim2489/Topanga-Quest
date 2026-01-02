using UnityEngine;
using UnityEngine.Rendering;

public class LevelMover : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 3;
    [SerializeField]private Player player;
    private bool stop;
    void Start()
    {
        if (player == null)
        {
            player = FindAnyObjectByType<Player>();
        }
        player.died+=Stop;
    }
    void Update()
    {
        if (stop)
        {
            return;
        }
        transform.position +=Vector3.left*moveSpeed*Time.deltaTime;
    }

    public void Stop()
    {
        stop = true;
    }
}
