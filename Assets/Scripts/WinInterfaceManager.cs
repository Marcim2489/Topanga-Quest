using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WinInterfaceManager : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI coinsText;
    [SerializeField]private TextMeshProUGUI rubyText;
    [SerializeField]Animator UISelector;
    [SerializeField]AudioSource sfx;
    [SerializeField]InputAction select;
    bool selected;
    float timer;
    bool canSelect;
    void Start()
    {
        canSelect = false;
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
        select.Enable();
    }

    void Update()
    {
        if(select.WasPressedThisFrame() == false)
        {
            canSelect = true;
        }
        if (select.WasPressedThisFrame() && canSelect)
        {
            select.Disable();
            Continue();
        }
        if (selected == false)
        {
            return;
        }
        timer+=Time.deltaTime;
        if (timer < 0.3f)
        {
            return;
        }
        if (GameManager.Instance.lastLevelJustPlayed)
        {
            GameManager.Instance.lastLevelJustPlayed = false;
            LevelLoader.Instance.LoadLevel("CompletedGame");
        }
        else
        {
            LevelLoader.Instance.LoadLevel("LevelMap");
        }
    }


    public void Continue()
    {
        if (selected)
        {
            return;
        }
        UISelector.SetTrigger("Select");
        sfx.Play();
        selected = true;
        timer = 0;
    }
}
