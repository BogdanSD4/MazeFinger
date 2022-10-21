using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class LuckySpin : MonoBehaviour
{
    [SerializeField] private Transform _handle;
    [SerializeField] private Transform _wheel;
    [SerializeField] private Transform _component;
    [Space]
    [SerializeField] private TextMeshProUGUI _spinAmountText;
    [SerializeField] private GameObject _adsIcon;
    [SerializeField] private GameObject _spinIcon;
    [SerializeField] private Transform _prizeIcon;
    [Space]
    [SerializeField] private UnityEvent _endSpin;
    [SerializeField] private UnityEvent _getReward;
    [SerializeField] private UnityEvent _startSpin;
    [SerializeField] private UnityEvent _playAds;

    private int _spinAmount;

    public int SpinAmount
    {
        get { return _spinAmount; }
        set 
        {
            _spinAmount = value;
            _spinAmountText.text = "x"+_spinAmount.ToString();
            PlayerPrefs.SetInt("Spin", SpinAmount);
            AdsIconChange();
        }
    }

    private Vector3 _ray;
    private float _speed = 0;
    private float _slowdown = 1f;
    private bool _result;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Spin"))
        {
            SpinAmount = PlayerPrefs.GetInt("Spin");
        }
        else SpinAmount = 3;

        float scale = (Constans.RealCameraHeight / Gameplay.CameraSize) /
            Constans.RealCameraWidth;

        _component.localScale = new Vector3(scale, scale, _component.localScale.z);

        gameObject.SetActive(false);
    }
    private void Update()
    {
        if(_speed > 0)
        {
            _wheel.Rotate(0, 0, _speed * Time.deltaTime);
            _speed -= _slowdown * Time.deltaTime;
            if(_speed <= 0)
            {
                _result = true;
                _ray = new Vector3(_handle.position.x, _handle.position.y, -10);
            }
        }
        if (_result)
        {
            RaycastHit2D hit = Physics2D.Raycast(_ray, -Vector3.forward);

            if (hit.transform != null)
            {
                hit.transform.GetComponent<WheelSector>().GetReward();
                _speed = 0;
                _result = false;
                _endSpin.Invoke();
                _getReward.Invoke();
            }
            else _wheel.Rotate(0, 0, 0.1f);
        }
    }

    public void StartAds()
    {
        if (_speed != 0 || _result) return;

        if (SpinAmount == 0)
        {
            _playAds.Invoke();
        }
        else
        {
            StartSpin();
        }
    }

    public void StartSpin()
    {
        _startSpin.Invoke();
        _speed = UnityEngine.Random.Range(500, 800);
        _slowdown = UnityEngine.Random.Range(70f, 100f);

        if (SpinAmount != 0)
        {
            SpinAmount--;
        }
    }

    public void GetPrize()
    {
        Constans.Interface.InterfaceAnim.SetTrigger("SpinReward");

        foreach (Transform i in _prizeIcon) Destroy(i.gameObject);

        Instantiate(WheelSector.Bonus, _prizeIcon);
    }

    public void AdsIconChange()
    {
        if(SpinAmount == 0)
        {
            _adsIcon.SetActive(true);
            _spinIcon.SetActive(false);
        }
        else if (_adsIcon.activeSelf)
        {
            _adsIcon.SetActive(false);
            _spinIcon.SetActive(true);
        }
    }
}
