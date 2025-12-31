using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelIcon : MonoBehaviour
{
    public string levelScene = "Level4";
    public string levelName;
    public bool unlocked;
    public bool containsLevel = true;
    public LevelIcon levelAbove;
    public LevelIcon levelBelow;
    public LevelIcon levelLeft;
    public LevelIcon levelRight;
    [SerializeField]private LevelIcon nextLevel;
    [SerializeField]private GameObject lockSprite;
    [SerializeField]private SpriteRenderer spriteRenderer;
    [SerializeField]private Sprite completedSprite;
    private LevelMapManager levelMapManager;
    void Start()
    {
        if (unlocked|| levelScene == GameManager.Instance.lastLevelPlayed)
        {
            Unlock();
        }
        if (GameManager.Instance.completedLevels.Contains(levelScene))
        {
            if (containsLevel)
            {
                spriteRenderer.sprite = completedSprite;
            }
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
        if (levelScene == GameManager.Instance.lastLevelPlayed)
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
