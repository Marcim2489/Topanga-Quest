using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinInterfaceManager : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI coinsText;
    [SerializeField]private TextMeshProUGUI rubyText;

    void Start()
    {
        int collectedCoins = GameManager.Instance.lastLevelCoins;
        int totalCoins = GameManager.Instance.lastLevelTotalCoins;
        if (collectedCoins > totalCoins)
        {
            collectedCoins = totalCoins;
        }
        coinsText.text = "Coins collected: "+ collectedCoins+"/"+totalCoins;
        if (GameManager.Instance.lastLevelRuby)
        {
            rubyText.text = "Ruby found!";
        }
        else
        {
            rubyText.text = "Ruby not found...";
        }
    }

    public void Continue()
    {
        LevelLoader.Instance.LoadLevel("LevelMap");
    }
}
