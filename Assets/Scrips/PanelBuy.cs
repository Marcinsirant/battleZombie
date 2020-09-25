using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBuy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabIconGunToBuy;
    public List<GameObject> gunsPrefab;

    public List<GunToBuy> propertiesGuns;
    
    // Start is called before the first frame update
    void Start()
    {
        // adding guns
        if (prefabIconGunToBuy != null) {
            for (int i = 0; i < gunsPrefab.Count; i++) {
                
                GameObject prefabInstance = GameObject.Instantiate(prefabIconGunToBuy) as GameObject;
                if (prefabInstance != null)
                {
                    var myScriptReference = prefabInstance.GetComponent<GunToBuy>();
                    propertiesGuns.Add(myScriptReference);
                    if (myScriptReference != null)
                    {
                        PropertiesGun propertiesGun = gunsPrefab[i].GetComponent<PropertiesGun>();
                        
                        //speedPlayerText.text = $"Speed Player: {gunsPrefab[i].GetComponent<PropertiesGun>().}";
                        myScriptReference.gunToSetActive = gunsPrefab[i];
                        myScriptReference.image.sprite = gunsPrefab[i].GetComponent<SpriteRenderer>().sprite;
                        myScriptReference.speedPlayerText.text = $"Player speed: {propertiesGun.speedPlayer}";
                        myScriptReference.reloadText.text = $"Reload: {propertiesGun.reload}";
                        myScriptReference.buttonText.text = $"{propertiesGun.price}-BUY";
                        if (DataPlayer.dataPlayer.gunsBought.Contains(propertiesGun.gunName))
                        {
                            if (DataPlayer.dataPlayer.setGunPrefab == gunsPrefab[i])
                            {
                                myScriptReference.buttonText.text = "USED"; 
                            }else
                                myScriptReference.buttonText.text = "SET";
                        }
                    }
                    prefabInstance.transform.SetParent(this.transform);
                }


                //prefabsGameLevel.transform.SetParent(gameObject.transform, true);
            }
        } 
    }

    public void resetButtonText()
    {
        for (int i = 0; i < propertiesGuns.Count; i++)
        {
            if (propertiesGuns[i].buttonText.text == "USED")
            {
                propertiesGuns[i].buttonText.text = "SET";
            }

            
        }
    }
}
