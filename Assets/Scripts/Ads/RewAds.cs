using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GoogleMobileAds.Api;
using System;

public class RewAds : MonoBehaviour
{
    [SerializeField] private AdsType _type;
    [SerializeField] private UnityEvent _event;

    private RewardedAd _rewardedAd;

    private const string _rewardID = "ca-app-pub-3940256099942544/5224354917";

    private void OnEnable()
    {
        _rewardedAd = new RewardedAd(_rewardID);
        AdRequest adRequest = new AdRequest.Builder().Build();
        _rewardedAd.LoadAd(adRequest);
        _rewardedAd.OnUserEarnedReward += HandleUserErnedReward;
    }

    private void HandleUserErnedReward(object sender, Reward e)
    {
        _event.Invoke();
        switch (_type)
        {
            case AdsType.Spin:
            case AdsType.Continue:
            default:
                break;
        }
    }

    public void ShowAds()
    {
        if (_rewardedAd.IsLoaded())
        {
            _rewardedAd.Show();
        }
    }
}
public enum AdsType
{
    Spin,
    Continue
}
