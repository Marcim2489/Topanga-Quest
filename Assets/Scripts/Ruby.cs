using UnityEngine;
using UnityEngine.Audio;

public class Ruby : MonoBehaviour
{
    [SerializeField]SoundEffect sfxPlayer;
    [SerializeField]AudioResource sound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerHitbox>()!= null)
        {
            FindFirstObjectByType<LevelManager>().rubyColected = true;
            SoundEffect s = Instantiate(sfxPlayer,transform.position,transform.rotation);
            s.PlaySFX(sound,1);
            Destroy(gameObject);
        }
    }
}
