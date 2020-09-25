using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GunToBuy : MonoBehaviour
{
    public TextMeshProUGUI speedPlayerText;

    public TextMeshProUGUI reloadText;

    public Image image;

    public Button buttonBuy;
    
    public GameObject gunToSetActive;

    public TextMeshProUGUI buttonText;

    
    void Start()
    {
        gameObject.transform.localScale = new Vector2(0.4f,0.4f);
    }

    private void Update()
    {
        buttonBuy.onClick.AddListener(()=>
        {
            if (buttonText.text == "USED")
            {
            }else if (buttonText.text == "SET")
            {
                GetComponentInParent<PanelBuy>().resetButtonText();
                //base.resetButtonText();
                buttonText.text = "USED";
                
                DataPlayer.dataPlayer.setGunPrefab = gunToSetActive;
            }else if (DataPlayer.dataPlayer.allCollectCoins >= gunToSetActive.GetComponent<PropertiesGun>().price)
            {
                DataPlayer.dataPlayer.allCollectCoins -= gunToSetActive.GetComponent<PropertiesGun>().price;
                DataPlayer.dataPlayer.gunsBought.Add(gunToSetActive.GetComponent<PropertiesGun>().gunName);
                GetComponentInParent<PanelStore>().updateCoins();
                buttonText.text = "SET";
            }

            
        });
    }
}
