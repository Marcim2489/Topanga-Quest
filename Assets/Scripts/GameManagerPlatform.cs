using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManagerPlatform : MonoBehaviour
{
    public Player player;
    public Canvas canvas;

    void Start()
    {
        if (player == null)
        {
            player = FindFirstObjectByType<Player>();
        }
        player.died += EnableGameOverLayout;
        
    }

    void EnableGameOverLayout()
    {
        // gameOverLayout.gameObject.SetActive(true);
        // gameOverLayout.rootVisualElement.Q<Button>("RestartButton").clicked += RestartGame;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
