using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get;private set;}
    public string[] levels {get;private set;} = {"Level 1", "DragonFly", "WaterLevel","Level4"};
    [HideInInspector] public List<string> completedLevels = new List<string>();
    [HideInInspector] public List<string> levelsWithAllCoins = new List<string>();
    [HideInInspector] public List<string> levelsWithRuby = new List<string>();
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
