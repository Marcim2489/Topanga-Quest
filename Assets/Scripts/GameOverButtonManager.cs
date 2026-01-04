using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameOverButtonManager : MonoBehaviour
{
    [SerializeField]Button tryAgainButton;
    [SerializeField]Animator tryAgainUISelector;
    [SerializeField]Button menuButton;
    [SerializeField]Animator menuUISelector;
    [SerializeField]AudioSource sfx;
    Button currentButton;
    [SerializeField]InputAction select;
    [SerializeField]InputAction changeButton;
    float timer;
    bool selected;
    bool canSelect;

    void Start()
    {
        GameManager.Instance.SaveGame();
        canSelect = false;
        SelectTryAgain();
        select.Enable();
        changeButton.Enable();
    }

    void Update()
    {
        if(select.WasPressedThisFrame() == false)
        {
            canSelect = true;
        }
        if (selected)
        {
            timer+=Time.deltaTime;
            if (timer < 0.3)
            {
                return;
            }
            if (currentButton == tryAgainButton)
            {
                ReturnToLevel();
            }
            else
            {
                BackToMenu();
            }
            return;
        }

        if (changeButton.WasPressedThisFrame())
        {
            if (currentButton == tryAgainButton)
            {
                SelectMenu();
            }
            else
            {
                SelectTryAgain();
            }
            
            return;
        }
        if (select.WasPressedThisFrame()&&canSelect)
        {
            if (currentButton == tryAgainButton)
            {
                TryAgainClicked();
            }
            else
            {
                MenuClicked();
            }
        }
    }

    void SelectTryAgain()
    {
        currentButton = tryAgainButton;
        tryAgainUISelector.gameObject.SetActive(true);
        menuUISelector.gameObject.SetActive(false);
    }

    void SelectMenu()
    {
        currentButton = menuButton;
        menuUISelector.gameObject.SetActive(true);
        tryAgainUISelector.gameObject.SetActive(false);
    }

    public void TryAgainClicked()
    {
        if (selected)
        {
            return;
        }
        SelectTryAgain();
        timer =0;
        selected = true;
        sfx.Play();
        tryAgainUISelector.SetTrigger("Select");
    }
    public void MenuClicked()
    {
        if (selected)
        {
            return;
        }
        SelectMenu();
        timer =0;
        selected = true;
        sfx.Play();
        menuUISelector.SetTrigger("Select");
    }

    void ReturnToLevel()
    {
        if(GameManager.Instance.lastLevelPlayed == "0")
        {
            LevelLoader.Instance.LoadLevel("LevelMap");
            return;
        }
        LevelLoader.Instance.LoadLevel(GameManager.Instance.lastLevelPlayed);
    }
    void BackToMenu()
    {
        LevelLoader.Instance.LoadLevel("Menu");
    }


}
