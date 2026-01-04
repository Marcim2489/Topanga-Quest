using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMap : MonoBehaviour
{
    public InputAction directionInput;
    public InputAction selectInput;
    public InputAction exitInput;
    public Animator animator;
    public SpriteRenderer sprite;
    bool canExit;
    private void Awake()
    {
        FindAnyObjectByType<CinemachineCamera>().transform.position = transform.position;
        FindAnyObjectByType<Camera>().transform.position = transform.position;
    }
    void Start()
    {
        canExit = false;
        directionInput.Enable();
        selectInput.Enable();
        exitInput.Enable();
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if(sprite == null)
        {
            sprite = GetComponent<SpriteRenderer>();
        }
    }
    void Update()
    {
        if (exitInput.WasPressedThisFrame() == false)
        {
            canExit = true;
        }
        if (exitInput.WasPressedThisFrame()&&canExit)
        {
            LevelLoader.Instance.LoadLevel("Menu");
        }
    }
}
