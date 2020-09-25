using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PermamentUI : MonoBehaviour
{
    public int coin = 0;
    public Text _CoinNumberText;

    public int healthPoint = 100;
    public Text _healthPointText;

    public static PermamentUI perm;

    public bool pauseMenuIsActive;

    public GameObject pauseMenuPanel;
    public GameObject pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        

        if (!perm)
        {
            perm = this;
        }
        else {
            Destroy(gameObject);
        }



    }
    public static void resetStat() {
        perm.coin = 0;
        perm._CoinNumberText.text = perm.coin.ToString();
        perm.healthPoint = 100;
        perm._healthPointText.text = perm.healthPoint.ToString();
    }

    public static void subHealthPoint(int subtraction) {
        perm.healthPoint -= subtraction;
        if (perm.healthPoint <=0) {
            perm.healthPoint = 0;
            FindObjectOfType<TilemapCollider2D>().enabled = false;
        }
        perm._healthPointText.text = perm.healthPoint.ToString();

    }

    public void pauseMenuSetActive()
    {
        pauseMenuPanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void resume()
    {
        pauseMenuPanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void backToMenu()
    {
        Time.timeScale = 1f;
        DataPlayer.dataPlayer.currentCollectCoins = 0;
        DataPlayer.dataPlayer.saveStat();
        DataPlayer.dataPlayer.panelNumber = 0;
        SceneManager.LoadScene(0);
    }

}
