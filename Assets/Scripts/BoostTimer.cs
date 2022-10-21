using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostTimer : MonoBehaviour
{
    [SerializeField] private Image _timerIcon;

    private float _startTime;
    private float _timer;

    private int _currentFactor;
    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            _timerIcon.fillAmount = _timer / _startTime;
        }
        else
        {
            if (_currentFactor != 0)
            {
                Gameplay.CurrentMultiplier -= _currentFactor;
                if (Gameplay.CurrentMultiplier < 1) 
                    Gameplay.CurrentMultiplier = 1;

                Constans.Interface.SetMultip();
                Restart();
            }
        }
    }

    public void Activate(float time, int factor) 
    {
        gameObject.SetActive(true);
        _timer += time;
        _startTime = _timer;
        _currentFactor += factor;

        if (Gameplay.CurrentMultiplier == 1) Gameplay.CurrentMultiplier = factor;
        else Gameplay.CurrentMultiplier += factor;

        Constans.Interface.SetMultip();
    }

    public void Restart()
    {
        gameObject.SetActive(false);
        _currentFactor = 0;
        _timer = 0;
    }
}
