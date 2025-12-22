using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class WinLayout : MonoBehaviour
{
    private UIDocument layout;
    void Start()
    {
        layout = GetComponent<UIDocument>();
        layout.rootVisualElement.Q<Button>("NextLevelButton").clicked += NextLevel;
        layout.rootVisualElement.Q<Button>("ExitButton").clicked += BackToMenu;
    }

    void NextLevel()
    {
        string[] allLevels = GameManager.Instance.levels;
        int nextLevelIndex = 1 + System.Array.FindIndex<string>(allLevels, level =>level == GameManager.Instance.lastLevelPlayed);
        if (nextLevelIndex > allLevels.Length-1)
        {
            
            BackToMenu();
            return;
        }
        LevelLoader.Instance.LoadLevel(allLevels[nextLevelIndex]);
    }

    void BackToMenu()
    {
        LevelLoader.Instance.LoadLevel("Menu");
    }

}
