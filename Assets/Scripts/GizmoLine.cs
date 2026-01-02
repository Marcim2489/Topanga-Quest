using UnityEngine;

public class GizmoLine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right*999999999);
    }
}
