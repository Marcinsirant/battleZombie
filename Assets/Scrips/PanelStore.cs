using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelStore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI allCoins;
    
    void Start()
    {
        if (DataPlayer.dataPlayer != null)
        {
            allCoins.text = DataPlayer.dataPlayer.allCollectCoins.ToString();
        }
    }

	public void updateCoins(){
	allCoins.text = DataPlayer.dataPlayer.allCollectCoins.ToString();
	}

}
