using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get;private set;}
    [HideInInspector] public List<string> completedLevels = new List<string>();
    [HideInInspector] public List<string> levelsWithAllCoins = new List<string>();
    [HideInInspector] public List<string> levelsWithRuby = new List<string>();
    [HideInInspector] public string lastLevelPlayed;
    [HideInInspector]public int lastLevelCoins;
    [HideInInspector]public int lastLevelTotalCoins;
    [HideInInspector]public bool lastLevelRuby;
    [HideInInspector]public bool completedGame;
    [HideInInspector]public bool lastLevelJustPlayed;
    string saveLocation;
    void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        saveLocation = Path.Combine(Application.persistentDataPath,"Topanga Save,json");
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();
    }

    public bool CollectedAllCoins(string levelName)
    {
        return levelsWithAllCoins.Contains(levelName);
    }

    public bool CollectedRuby(string levelName)
    {
        return levelsWithRuby.Contains(levelName);
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData
        {
            ScompletedLevels = completedLevels,
            SlevelsWithAllCoins = levelsWithAllCoins,
            SlevelsWithRuby = levelsWithRuby,
            SlastLevelPlayed=lastLevelPlayed,
            ScompletedGame = completedGame
        };
        File.WriteAllText(saveLocation,JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData data = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
            completedLevels = data.ScompletedLevels;
            levelsWithAllCoins = data.SlevelsWithAllCoins;
            levelsWithRuby = data.SlevelsWithRuby;
            lastLevelPlayed = data.SlastLevelPlayed;
            completedGame=data.ScompletedGame;
        }
        else
        {
            SaveGame();
        }
    }
}
