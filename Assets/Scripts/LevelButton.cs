using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField]private string levelName = "Level4";
    [SerializeField]private GameObject coinIndicator;
    [SerializeField]private GameObject rubyIndicator;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Select);
        coinIndicator.SetActive(GameManager.Instance.CollectedAllCoins(levelName));
        rubyIndicator.SetActive(GameManager.Instance.CollectedRuby(levelName));
    }

    void Select()
    {
        GameManager.Instance.lastLevelPlayed = levelName;
        LevelLoader.Instance.LoadLevel(levelName);
    }
}
