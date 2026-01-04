using UnityEngine;
using UnityEngine.InputSystem;

public class MenuButtonManager : MonoBehaviour
{
    float timer;
    bool clicked;
    [SerializeField]Animator UISelector;
    [SerializeField]AudioSource sfx;
    [SerializeField]InputAction select;
    [SerializeField]GameObject completionIndicator;
    bool canSelect;

    void Start()
    {
        canSelect = false;
        select.Enable();
        if (GameManager.Instance.completedGame)
        {
            completionIndicator.SetActive(true);
        }
        else
        {
            completionIndicator.SetActive(false);
        }
    }
    void Update()
    {
        if(select.WasPressedThisFrame() == false)
        {
            canSelect = true;
        }
        if (select.WasPressedThisFrame()&&canSelect)
        {
            select.Disable();
            StartGame();
        }
        if(clicked == false)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer < 0.3f)
        {
            return;
        }
        LevelLoader.Instance.LoadLevel("LevelMap");
        clicked = false;
    }

    public void StartGame()
    {
        if (clicked)
        {
            return;
        }
        clicked = true;
        UISelector.SetTrigger("Select");
        timer = 0;
        sfx.Play();
    }
}
