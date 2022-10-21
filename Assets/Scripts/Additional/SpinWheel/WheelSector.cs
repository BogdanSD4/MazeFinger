using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WheelSector : MonoBehaviour
{
    [SerializeField] private Transform _bonus;
    [SerializeField] private UnityEvent _reward;

    public static Transform Bonus;
    public void GetReward()
    {
        _reward.Invoke();
        Bonus = _bonus;
    }
}
