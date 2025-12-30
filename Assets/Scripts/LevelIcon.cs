using UnityEngine;

public class LevelIcon : MonoBehaviour
{
    public string levelName = "Level4";
    public bool unlocked;
    public LevelIcon levelAbove;
    public LevelIcon levelBelow;
    public LevelIcon levelLeft;
    public LevelIcon levelRight;
    [SerializeField]private LevelIcon nextLevel;
    [SerializeField]private GameObject lockSprite;
    private LevelMapManager levelMapManager;
    void Start()
    {
        if (unlocked)
        {
            Unlock();
        }
        if (GameManager.Instance.completedLevels.Contains(levelName))
        {
            Unlock();
            if (nextLevel != null)
            {
                nextLevel.Unlock();
            }
        }
        if (unlocked == false)
        {
            return;
        }
        levelMapManager = FindAnyObjectByType<LevelMapManager>();
        if (levelName == GameManager.Instance.lastLevelPlayed)
        {
            levelMapManager.TeleportPlayer(this);
        }
    }
    public void Unlock()
    {
        unlocked = true;
        lockSprite.SetActive(false);
    }
}
