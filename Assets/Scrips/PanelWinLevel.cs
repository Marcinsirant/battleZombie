using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelWinLevel : MonoBehaviour
{

    [SerializeField]private TextMeshProUGUI winCoinsText;
    [SerializeField]private TextMeshProUGUI currentLevelText;
    // Start is called before the first frame update
    void Start()
    {
        if (DataPlayer.dataPlayer != null)
        {
            currentLevelText.text = DataPlayer.dataPlayer.currentLevel.ToString();
            winCoinsText.text = DataPlayer.dataPlayer.currentCollectCoins.ToString();  
        }
    }
    
}
