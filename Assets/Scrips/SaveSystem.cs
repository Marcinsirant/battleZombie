using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using JetBrains.Annotations;

public class SaveSystem 
{
    public static void SaveDataPlayer(DataPlayer dataPlayer)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.properties";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        SavePlayerData data = new SavePlayerData(dataPlayer);
        formatter.Serialize(stream, data);
        
        stream.Close();
    }

    public static SavePlayerData LoadDataPlayer()
    {
        string path = Application.persistentDataPath + "/player.properties";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream= new FileStream(path, FileMode.Open);

            SavePlayerData data = formatter.Deserialize(stream) as SavePlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("null data");
            return null;
        }
    }
}
