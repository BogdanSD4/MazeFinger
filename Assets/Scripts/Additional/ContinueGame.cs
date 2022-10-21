using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueGame : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    [SerializeField] private Image _timerImage;
    [SerializeField] private GameObject _button;

    private float _timer;

    public static int _repeatCount = 1;
    private void OnEnable()
    {
        if (_repeatCount > 0)
        {
            _timer = _maxTime;
            _button.SetActive(true);
            _repeatCount--;
        }
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0) _button.SetActive(false);
            else
            {
                _timerImage.fillAmount = _timer / _maxTime;
            }
        }
    }
}
