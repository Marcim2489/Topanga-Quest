using UnityEngine;
using UnityEngine.Audio;

public class BackgroundMusicManager : MonoBehaviour
{
    [SerializeField]private AudioResource music;
    [SerializeField]private bool loop = true;
    void Start()
    {
        if(music == null)
        {
            return;
        }
        BackgroundMusicPlayer.Instance.PlayMusic(music);
        BackgroundMusicPlayer.Instance.SetLoopMode(loop);
    }
}
