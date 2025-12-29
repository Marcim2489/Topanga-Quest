using UnityEngine;

public class GameOverButtonManager : MonoBehaviour
{
    public void ReturnToLevel()
    {
        LevelLoader.Instance.LoadLevel(GameManager.Instance.lastLevelPlayed);
    }
    public void BackToMenu()
    {
        LevelLoader.Instance.LoadLevel("Menu");
    }
}
