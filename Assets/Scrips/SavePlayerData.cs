using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavePlayerData
{
    
    public int levelFinished;
    public int allCollectCoins;
    public List<string> gunsBought;
    public SavePlayerData(DataPlayer dataPlayer)
    {
        levelFinished = dataPlayer.levelFinished;
        allCollectCoins = dataPlayer.allCollectCoins;
        gunsBought = dataPlayer.gunsBought;
    }
}
