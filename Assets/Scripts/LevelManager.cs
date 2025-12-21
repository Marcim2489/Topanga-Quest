using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.lastLevelPlayed = SceneManager.GetActiveScene().name;
    }
}
