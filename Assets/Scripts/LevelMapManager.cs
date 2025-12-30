using UnityEngine;

public class LevelMapManager : MonoBehaviour
{
    [HideInInspector]public LevelIcon currentLevelSelected;
    [SerializeField]private PlayerMap player;
    private bool playerMoving;
    private LevelIcon targetLevel;
    void Start()
    {
        
    }

    void Update()
    {
        if (playerMoving)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetLevel.transform.position, 3*Time.deltaTime);
            if(player.transform.position == targetLevel.transform.position)
            {
                currentLevelSelected = targetLevel;
                targetLevel = null;
                playerMoving = false;
            }
            return;
        }
        if (player.selectInput.WasPressedThisFrame() && playerMoving == false)
        {
            LevelLoader.Instance.LoadLevel(currentLevelSelected.levelName);
        }
        
        Vector2 direction = player.directionInput.ReadValue<Vector2>();
        if(direction.x > 0)
        {
            MovePlayer(currentLevelSelected.levelRight);
        }else if(direction.x < 0)
        {
            MovePlayer(currentLevelSelected.levelLeft);
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
        targetLevel = targetLvl;
        playerMoving = true;
    }

    public void TeleportPlayer(LevelIcon targetLvl)
    {
        targetLevel = targetLvl;
        player.transform.position = targetLevel.transform.position;
        currentLevelSelected = targetLevel;
        targetLevel = null;
    }
}
