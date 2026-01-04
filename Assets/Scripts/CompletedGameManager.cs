using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class CompletedGameManager : MonoBehaviour
{
    float timer;
    bool clicked;
    [SerializeField]Animator UISelector;
    [SerializeField]AudioSource sfx;
    [SerializeField]InputAction select;

    bool canSelect;

    void Start()
    {
        canSelect = false;
        select.Enable();
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
            BackToMenu();
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
        LevelLoader.Instance.LoadLevel("Menu");
        clicked = false;
    }

    public void BackToMenu()
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
