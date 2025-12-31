using UnityEngine;
using UnityEngine.Audio;

public class BackgroundMusicPlayer : MonoBehaviour
{
    public static BackgroundMusicPlayer Instance {get;private set;}
    [SerializeField]AudioSource audioPlayer;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioResource music)
    {
        if(audioPlayer.resource == music)
        {
            return;
        }
        audioPlayer.Stop();
        audioPlayer.resource = music;
        audioPlayer.Play();
    }
    public void SetLoopMode(bool l)
    {
        audioPlayer.loop = l;
    }
    
    public void SetVolume(float volume)
    {
        audioPlayer.volume = volume;
    }

    public void StopMusic()
    {
        audioPlayer.resource = null;
        audioPlayer.Stop();
    }
}
