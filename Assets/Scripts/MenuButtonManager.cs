using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{
    public void StartGame()
    {
         LevelLoader.Instance.LoadLevel("LevelMap");
    }
}
