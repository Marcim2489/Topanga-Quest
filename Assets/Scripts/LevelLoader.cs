using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance {get; private set;}
    private Player player;
    public float loadTime = 1;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // private void Start()
    // {
    //     if (player == null)
    //     {
    //         player = FindAnyObjectByType<Player>();
    //     }
    //     if (player != null)
    //     {
    //         player.died += LoadGameOver;
    //     }
    // }
    public void SetPlayer(Player p)
    {
        player = p;
        player.died += LoadGameOver;
    }
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    private void LoadGameOver()
    {
        StartCoroutine(GameOver());
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(player.deathAnimationTime);
        SceneManager.LoadScene("GameOver");
    }
}