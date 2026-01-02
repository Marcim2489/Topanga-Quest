using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    [SerializeField]private LevelMover lvMover;
    [SerializeField]private PlayerFly player;
    [SerializeField]private GameObject barrier;

    void Start()
    {
        if (lvMover == null)
        {
            lvMover = FindAnyObjectByType<LevelMover>();
        }
        if(player == null)
        {
            player = FindAnyObjectByType<PlayerFly>();
        }
    }

    public void Trigger()
    {
        lvMover.Stop();
        player.EndLevel();
        Destroy(barrier);
    }
}
