using UnityEngine;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    private UIDocument gameOverLayout;

    void Start()
    {
        gameOverLayout = GetComponent<UIDocument>();
        gameOverLayout.rootVisualElement.Q<Button>("ContinueButton").clicked += ReturnToLevel;
        gameOverLayout.rootVisualElement.Q<Button>("ExitButton").clicked += BackToMenu;
    }

    void ReturnToLevel()
    {
        LevelLoader.Instance.LoadLevel(GameManager.Instance.lastLevelPlayed);
    }
    void BackToMenu()
    {
        LevelLoader.Instance.LoadLevel("Menu");
    }
}
