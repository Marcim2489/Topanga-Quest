using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField]GameObject door;
    [SerializeField]Skullex boss;
    [SerializeField]AudioSource bossMusicPlayer;
    [SerializeField]CinemachineCamera cam;

    void Start()
    {
        bossMusicPlayer.Stop();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHitbox>()!= null)
        {
            Trigger();
        }
    }

    void Trigger()
    {
        door.SetActive(true);
        cam.Follow = bossMusicPlayer.gameObject.transform;
        cam.LookAt = bossMusicPlayer.gameObject.transform;
        foreach (Cannon cannon in FindObjectsByType<Cannon>(0))
        {
            cannon.Deactivate();
        }
        BackgroundMusicPlayer.Instance.StopMusic();
        bossMusicPlayer.Play();
        boss.Trigger();
        Destroy(gameObject);
    }
}
