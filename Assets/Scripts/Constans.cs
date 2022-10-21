using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(1)]
public class Constans : MonoBehaviour
{
    [SerializeField] private Transform _levelScroll;
    [SerializeField] private InterFace _interface;
    [SerializeField] private Gameplay _gameplay;
    [SerializeField] private Transform _levelPrefab;
    [SerializeField] private BoostMenu _boostMenu;
    [SerializeField] private BoostTimer _boostTimer;
    [SerializeField] private LuckySpin _luckySpin;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private AdsManager _adsManager;

    public static Transform LevelScroll;
    public static InterFace Interface;
    public static Gameplay Gameplay;
    public static Transform LevelPrefab;
    public static BoostMenu BoostMenu;
    public static BoostTimer BoostTimer;
    public static LuckySpin LuckySpin;
    public static AudioManager AudioManager;
    public static AdsManager AdsManager;

    public const float RealCameraHeight = 10f;
    public const float CurrentCameraHeight = 14f;
    public const float RealCameraWidth = 6f;
    private void Awake()
    {
        LevelScroll = _levelScroll;
        Interface = _interface;
        Gameplay = _gameplay;
        LevelPrefab = _levelPrefab;
        BoostMenu = _boostMenu;
        BoostTimer = _boostTimer;
        LuckySpin = _luckySpin;
        AudioManager = _audioManager;
        AdsManager = _adsManager;
    }
}
