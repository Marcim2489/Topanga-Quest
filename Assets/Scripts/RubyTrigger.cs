using UnityEngine;

public class RubyTrigger : MonoBehaviour
{
    [SerializeField]private float speed = 5;
    [SerializeField]private Ruby ruby;

    bool triggered;
    public void Trigger()
    {
        if (triggered)
        {
            return;
        }
        Ruby r = Instantiate(ruby, transform.position, transform.rotation);
        r.gameObject.GetComponent<Rigidbody2D>().linearVelocityX = -speed;
        Destroy(gameObject);
    }
}
