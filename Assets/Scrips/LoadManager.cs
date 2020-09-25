using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    [HideInInspector]public enum Panel 
    {
        MainMenu = 0,
        PanelWinLevel = 1,
    };
    [HideInInspector]public Panel panel;
    [SerializeField] private List<GameObject> panels;

    
    
    // Start is called before the first frame update
    void Start()
    {
        if (DataPlayer.dataPlayer != null)
        {
           panels[(int)DataPlayer.dataPlayer.panelNumber].SetActive(true); 
        }
        else
        {
            panels[0].SetActive(true);
        }


    }
    
}
