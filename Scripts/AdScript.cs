using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using System;

public class AdScript : MonoBehaviour
{
    public Text adStatus;

    string app_id = "ca-app-pub-1272631982878279~8240101493";
    string rewarded_id = "ca-app-pub-1272631982878279/1094456258";

    private RewardedAd rewardviseo;
    public GameObject rewardbutton;

    public Damage carscript;



    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(app_id);
        
        rewardviseo = new RewardedAd(rewarded_id);

        // Called when an ad request has successfully loaded.
        this.rewardviseo.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardviseo.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardviseo.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardviseo.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardviseo.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardviseo.OnAdClosed += HandleRewardedAdClosed;
        requestrewardedvideo();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void requestrewardedvideo() {
        


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardviseo.LoadAd(request);
    }

    public void showVideoRewardAd() {
        if (rewardviseo.IsLoaded())
        {
            rewardviseo.Show();
        }
        else {
            Debug.Log("Video is not Loaded");
        }
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        requestrewardedvideo();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);

        carscript.player.cash += carscript.moneyearn;
        carscript.money.text = (carscript.moneyearn * 2).ToString();
        SaveSystem.SavePlayer(carscript.player);
        rewardbutton.SetActive(false);

    }

}
