using UnityEngine;
using UnityEngine.Audio;

public class Coin : MonoBehaviour
{
    [SerializeField]SoundEffect sfxPlayer;
    [SerializeField]AudioResource sound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerHitbox>()!= null)
        {
            FindFirstObjectByType<LevelManager>().coinsColected++;
            SoundEffect s = Instantiate(sfxPlayer,transform.position,transform.rotation);
            s.PlaySFX(sound);
            Destroy(gameObject);

        }
    }
}
