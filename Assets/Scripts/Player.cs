using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] protected int moveSpeed = 400;
    [SerializeField] protected Rigidbody2D m_rigidBody;
    [SerializeField] protected Animator m_animator;
    [SerializeField] protected SpriteRenderer m_spriteRenderer;

}
