using UnityEngine;
using UnityEngine.Audio;

public class SoundEffect : MonoBehaviour
{
    public AudioSource sfxPlayer;

    void Update()
    {
        if (sfxPlayer.resource == null)
        {
            return;
        }
        if (sfxPlayer.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
    public void PlaySFX(AudioResource sfx)
    {
        sfxPlayer.resource = sfx;
        sfxPlayer.Play();
    }
}
