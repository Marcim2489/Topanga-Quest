using UnityEngine;
using UnityEngine.Audio;

public class SoundEffect : MonoBehaviour
{
    [SerializeField]AudioSource sfxPlayer;

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
    public void PlaySFX(AudioResource sfx, float volume)
    {
        sfxPlayer.volume = volume;
        sfxPlayer.resource = sfx;
        sfxPlayer.Play();
    }
}
