using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlayer : MonoBehaviour
{
    public int panelNumber = 0; // 0 is mainManu; 1 is panel with level
    public int currentLevel;
    public int levelFinished;
    public int currentCollectCoins;
    public int allCollectCoins = 0;
    public static DataPlayer dataPlayer;

    public GameObject setGunPrefab;
    public List<string> gunsBought;
    
    void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
        if (!dataPlayer)
        {
            
            dataPlayer = this;
            dataPlayer.panelNumber = 0;
            dataPlayer.levelFinished = 0;
            LoadStat();
        }
        else {
            
            Destroy(gameObject);
        }

        
        dataPlayer.allCollectCoins += dataPlayer.currentCollectCoins;
       
    }

    public void saveStat()
    {
     SaveSystem.SaveDataPlayer(dataPlayer);   
    }

    public void LoadStat()
    {
        SavePlayerData data = SaveSystem.LoadDataPlayer();
        dataPlayer.levelFinished = data.levelFinished;
        dataPlayer.allCollectCoins = data.allCollectCoins;
        dataPlayer.gunsBought = data.gunsBought;
    }


}
