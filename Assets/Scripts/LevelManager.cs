using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [HideInInspector]public int coinsColected;
    [HideInInspector]public bool rubyColected;
    private int totalCoins;
    void Start()
    {
        GameManager.Instance.lastLevelPlayed = SceneManager.GetActiveScene().name;
        totalCoins = FindObjectsByType<Coin>(0).Length;
    }

    private bool CollectedAllCoins()
    {
        if (coinsColected >= totalCoins && totalCoins!=0)
        {
            return true;
        }
        return false;
    }

    public void WhatWasCollected()
    {
        if (CollectedAllCoins())
        {
            GameManager.Instance.levelsWithAllCoins.Add(SceneManager.GetActiveScene().name);
        }
        if (rubyColected)
        {
            GameManager.Instance.levelsWithRuby.Add(SceneManager.GetActiveScene().name);
        }
    }
}
