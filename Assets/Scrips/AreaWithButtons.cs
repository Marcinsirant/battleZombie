using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AreaWithButtons : MonoBehaviour
{
    public List<ButtonScript> buttons;
    public List<GameObject> objectsToSwap;
    public GameObject backToMenuButton;
    public GameObject aboutArtistPanel;

    private void Start()
    {
        DataPlayer.dataPlayer.saveStat();
        backToMenuButton.SetActive(false);
    }
    public void Subscribe(ButtonScript button) {
        if (buttons == null) {
            buttons = new List<ButtonScript>();
        }
        buttons.Add(button);
    }

    public void ChangePanel(ButtonScript button) {
        int index = button.transform.GetSiblingIndex();
        objectsToSwap[index].SetActive(true);
        gameObject.SetActive(false);
        backToMenuButton.SetActive(true);
    }
    
    public void BackToMenu() {
        foreach (GameObject panel in objectsToSwap) {
            panel.SetActive(false);
        }
        gameObject.SetActive(true);
        backToMenuButton.SetActive(false);
        
        DataPlayer.dataPlayer.saveStat();
    }

    public void ExitGame() {
        
        aboutArtistPanel.SetActive(true);
        StartCoroutine(ExitIE());
        gameObject.SetActive(false);
        Invoke("Exit", 2.0f);
        
    }
    
    IEnumerator ExitIE()
    {
        yield return new WaitForSeconds(2.0f);
        Application.Quit();
        
    }
    public void Exit()
    {
        Application.Quit();
    }
}
