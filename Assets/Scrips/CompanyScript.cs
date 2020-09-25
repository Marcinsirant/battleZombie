using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompanyScript : MonoBehaviour
{

    public GameObject prefabsGameLevel;
    public List<String> scenes;

    // Start is called before the first frame update
    void Start()
    {
        scenes = new List<string>();
        var sceneNumber = SceneManager.sceneCountInBuildSettings;
        for (int i = 1; i<sceneNumber; i++)
        {
            scenes.Add(Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i)));
        }

        if (prefabsGameLevel != null) {
            for (int i = 1; i <= scenes.Count; i++) {
                if (DataPlayer.dataPlayer.levelFinished+1 >= i)
                {
                    GameObject prefabInstance = GameObject.Instantiate(prefabsGameLevel) as GameObject;
                                  if (prefabInstance != null)
                                  {
                                      var myScriptReference = prefabInstance.GetComponent<LevelScript>();
                                      if (myScriptReference != null)
                                      {
                                          myScriptReference.init();
                                          myScriptReference.setNumber(i);
                                      }
                                      prefabInstance.transform.SetParent(this.transform);
                                      prefabInstance.transform.localScale = new Vector2(1,1);
                                  }  
                }

              


                //prefabsGameLevel.transform.SetParent(gameObject.transform, true);
            }
        }    
    }
    
}
