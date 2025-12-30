using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMap : MonoBehaviour
{
    public InputAction directionInput;
    public InputAction selectInput;
    public Animator animator;
    public SpriteRenderer sprite;
    void Start()
    {
        directionInput.Enable();
        selectInput.Enable();
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if(sprite == null)
        {
            sprite = GetComponent<SpriteRenderer>();
        }
    }
}
