using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get;private set;}
    public string[] levels {get;private set;} = {"Level4", "DragonFly", "WaterLevel","Level 1"};
    [HideInInspector] public List<string> completedLevels = new List<string>();
    [HideInInspector] public List<string> levelsWithAllCoins = new List<string>();
    [HideInInspector] public List<string> levelsWithRuby = new List<string>();
    [HideInInspector] public string lastLevelPlayed;
    [HideInInspector]public int lastLevelCoins;
    [HideInInspector]public int lastLevelTotalCoins;
    [HideInInspector]public bool lastLevelRuby;

    void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        lastLevelPlayed = "Level4";
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool CollectedAllCoins(string levelName)
    {
        return levelsWithAllCoins.Contains(levelName);
    }

    public bool CollectedRuby(string levelName)
    {
        return levelsWithRuby.Contains(levelName);
    }
}
