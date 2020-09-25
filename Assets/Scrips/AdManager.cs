using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    string gameId = "3821619";
    bool testMode = true;
    ShowResult showResult;
    void Start () {
        Advertisement.AddListener (this);
        Advertisement.Initialize (gameId, testMode);
    }
    
    public void viewAd()
    {
        if (Advertisement.IsReady())
        {
            Debug.Log("ads");
            Advertisement.Show("rewardedVideo");
            
        }
        else
        {
            Debug.Log("no ads");
        }
    }
    
    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        
        if (showResult == ShowResult.Finished)
        {
            Debug.Log("finished");
            DataPlayer.dataPlayer.allCollectCoins =DataPlayer.dataPlayer.allCollectCoins + 100;
            gameObject.GetComponent<PanelStore>().updateCoins();
        } else if (showResult == ShowResult.Skipped) {
            // Do not reward the user for skipping the ad.
        } else if (showResult == ShowResult.Failed) {
            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }
    
    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == gameId) {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    } 

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy() {
        Advertisement.RemoveListener(this);
    }
    
}
