using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.Events;

public class AdsManager : MonoBehaviour
{
    
    private void Awake()
    {
        MobileAds.Initialize(initStatus => {});
    }
}
