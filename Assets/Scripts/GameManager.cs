using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get;private set;}
    public string[] levels {get;private set;} = {"Level 1", "DragonFly", "WaterLevel"};
    [HideInInspector] public string[] completedLevels;
    [HideInInspector] public string lastLevelPlayed = "Level 1";

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
}
