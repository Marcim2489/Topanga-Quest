using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinInterfaceManager : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI coinsText;
    [SerializeField]private TextMeshProUGUI rubyText;

    void Start()
    {
        coinsText.text = "Coins collected: "+ GameManager.Instance.lastLevelCoins+"/"+GameManager.Instance.lastLevelTotalCoins;
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
        LevelLoader.Instance.LoadLevel("LevelSelection");
    }
}
