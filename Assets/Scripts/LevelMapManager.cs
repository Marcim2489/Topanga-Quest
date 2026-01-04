using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class LevelMapManager : MonoBehaviour
{
    [HideInInspector]public LevelIcon currentLevelSelected;
    [SerializeField]private PlayerMap player;
    private bool playerMoving;
    private LevelIcon targetLevel;
    private bool levelSelected;
    private float timer;
    [SerializeField]private TextMeshProUGUI levelNameText;
    [SerializeField]private GameObject panel;
    [SerializeField]private GameObject coinImage;
    [SerializeField]private GameObject rubyImage;
    [SerializeField]private SoundEffect sfxPlayer;
    [SerializeField]private AudioResource selectSFX;
    void Update()
    {
        if (levelSelected)
        {
            timer += Time.deltaTime;
            if(timer>= 1f)
            {
                LevelLoader.Instance.LoadLevel(currentLevelSelected.levelScene);
            }
            return;
        }
        if (playerMoving)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetLevel.transform.position, 3*Time.deltaTime);
            if(player.transform.position == targetLevel.transform.position)
            {
                currentLevelSelected = targetLevel;
                ShowLevelName(currentLevelSelected);
                CheckWhatWasCollected(currentLevelSelected);
                targetLevel = null;
                playerMoving = false;
                player.animator.SetBool("Moving",false);
            }
            return;
        }
        if (player.selectInput.WasPressedThisFrame() && playerMoving == false && currentLevelSelected.containsLevel)
        {
            player.animator.SetTrigger("Selected");
            levelSelected = true;
            BackgroundMusicPlayer.Instance.StopMusic();
            SoundEffect s = Instantiate(sfxPlayer);
            s.PlaySFX(selectSFX,1);
            player.exitInput.Disable();
            return;
        }
        
        Vector2 direction = player.directionInput.ReadValue<Vector2>();
        if(direction.x > 0)
        {
            MovePlayer(currentLevelSelected.levelRight);
            player.sprite.flipX = false;
        }else if(direction.x < 0)
        {
            MovePlayer(currentLevelSelected.levelLeft);
            player.sprite.flipX = true;
        }else if(direction.y > 0)
        {
            MovePlayer(currentLevelSelected.levelAbove);
        }else if(direction.y < 0)
        {
            MovePlayer(currentLevelSelected.levelBelow);
        }
    }


    void MovePlayer(LevelIcon targetLvl)
    {
        if (targetLvl == null)
        {
            return;
        }
        if(targetLvl.unlocked == false)
        {
            return;
        }
        HideLevelInfo();
        targetLevel = targetLvl;
        playerMoving = true;
        player.animator.SetBool("Moving",true);
    }

    public void TeleportPlayer(LevelIcon targetLvl)
    {
        currentLevelSelected = targetLvl;
        player.transform.position = currentLevelSelected.transform.position;
        ShowLevelName(currentLevelSelected);
        CheckWhatWasCollected(currentLevelSelected);
    }

    void ShowLevelName(LevelIcon lvl)
    {
        if(lvl.containsLevel == false)
        {
            levelNameText.gameObject.SetActive(false);
            panel.gameObject.SetActive(false);
            return;
        }
        levelNameText.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);
        levelNameText.text = lvl.levelName;
    }

    void CheckWhatWasCollected(LevelIcon lvl)
    {
        if (GameManager.Instance.levelsWithAllCoins.Contains(lvl.levelScene))
        {
            coinImage.SetActive(true);
        }
        else
        {
            coinImage.SetActive(false);
        }
        if(GameManager.Instance.levelsWithRuby.Contains(lvl.levelScene))
        {
            rubyImage.SetActive(true);
        }
        else
        {
            rubyImage.SetActive(false);
        }
    }

    void HideLevelInfo()
    {
        coinImage.SetActive(false);
        rubyImage.SetActive(false);
        levelNameText.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
    }
}
