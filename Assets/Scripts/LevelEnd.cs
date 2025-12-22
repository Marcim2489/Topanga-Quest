using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHitbox player = collision.gameObject.GetComponent<PlayerHitbox>();
        if (player != null)
        {
            GameManager.Instance.lastLevelPlayed = SceneManager.GetActiveScene().name;
            GameManager.Instance.completedLevels.Append<string>(SceneManager.GetActiveScene().name);
            LevelLoader.Instance.LoadLevel("CompletedLevel");
        }
    }
}
