using UnityEditor;
using UnityEngine;

public class Skullor : Enemy
{
    [SerializeField]private float detectorRadius;
    [SerializeField]private LayerMask detectorLayerMask;
    [SerializeField]private float movesSpeed = 2;
    [SerializeField]private Player player;

    public override void Start()
    {
        base.Start();
        if (player == null)
        {
            player = FindAnyObjectByType<Player>();
        }
    }

    void Update()
    {
        if (Physics2D.CircleCast(transform.position, detectorRadius, Vector2.right, 0, detectorLayerMask))
        {
            m_rigidBody.linearVelocity = movesSpeed * (player.transform.position-transform.position);
        }
        else
        {
            m_rigidBody.linearVelocity = Vector3.zero;
        }
    }

    private void OnDrawGizmosSelected() {
        Handles.DrawWireDisc(transform.position,Vector3.forward,detectorRadius);
    }
}
