using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMap : MonoBehaviour
{
    public InputAction directionInput;
    public InputAction selectInput;

    void Start()
    {
        directionInput.Enable();
        selectInput.Enable();
    }
}
