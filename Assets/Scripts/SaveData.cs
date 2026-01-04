using UnityEngine;
using System.Collections.Generic;
using System.IO;


[System.Serializable]
public class SaveData
{
    [HideInInspector]public List<string> ScompletedLevels;
    [HideInInspector]public List<string> SlevelsWithAllCoins;
    [HideInInspector]public List<string> SlevelsWithRuby;
    [HideInInspector]public string SlastLevelPlayed;
    [HideInInspector]public bool ScompletedGame;
}
