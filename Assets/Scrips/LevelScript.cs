using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour, IPointerClickHandler
{

    private TextMeshProUGUI text;
    private int number = 0;
    public CompanyScript companyScript;

    
    // Start is called before the first frame update
    public void init()
    {
        companyScript = FindObjectOfType<CompanyScript>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void setNumber(int number) {
       
        this.number = number;
        text.text = this.number.ToString(); 
        
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        DataPlayer.dataPlayer.currentLevel = number;
        SceneManager.LoadScene(companyScript.scenes[number-1]);
    }
}
