using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private UIDocument menuLayout;

    void Start()
    {
        menuLayout = GetComponent<UIDocument>();
        menuLayout.rootVisualElement.Q<Button>("StartButton").clicked += StartPressed;
        // menuLayout.rootVisualElement.Q<Button>("ExitButton").clicked += ExitPressed;
    }


    void StartPressed()
    {
        LevelLoader.Instance.LoadLevel("LevelSelection");
    }

    // void ExitPressed()
    // {
    //     // EditorApplication.isPlaying = false;
    //     Application.Quit();
    // }
}
