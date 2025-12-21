using UnityEngine;
using UnityEngine.UIElements;

public class LevelSelector : MonoBehaviour
{
    public void GoToLevel(int level)
    {
        string levelName;
        switch (level)
        {
            case 1:
                levelName = "Level 1";
                break;
            case 2:
                levelName = "DragonFly";
                break;
            case 3:
                levelName = "WaterLevel";
                break;
            default:
                levelName = "Level 1";
                break;
        }
        GameManager.Instance.lastLevelPlayed = levelName;
        Debug.Log(GameManager.Instance.lastLevelPlayed = levelName);
        LevelLoader.Instance.LoadLevel(levelName);
    }
}
