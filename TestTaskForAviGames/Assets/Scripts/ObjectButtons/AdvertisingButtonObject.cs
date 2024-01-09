using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Analytics;

public class AdvertisingButtonObject : MonoBehaviour, IPointerClickHandler
{
    private void Start()
    {
        int adTypes = AppodealAdType.RewardedVideo;
        string appKey = "YOUR_APPODEAL_APP_KEY";
        Appodeal.Initialize(appKey, adTypes);
    }
    private void OnEnable()
    {
        AppodealCallbacks.RewardedVideo.OnFinished += OnAppodealSuccessfulComplete;
    }
    private void OnDisable()
    {
        AppodealCallbacks.RewardedVideo.OnFinished -= OnAppodealSuccessfulComplete;
    }
    private void OnAppodealSuccessfulComplete(object sender, EventArgs e)
    {
        Debug.Log("You watched video");
        GameAnalytics.gameAnalytics.RewardedAd();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (Appodeal.IsLoaded(AppodealAdType.RewardedVideo))
        {
            Appodeal.Show(AppodealShowStyle.RewardedVideo);
        }
    }
}
