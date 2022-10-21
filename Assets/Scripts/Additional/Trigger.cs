using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private TriggerType _type;
    [SerializeField] private UnityEvent _booster;
    private void OnMouseEnter()
    {
        switch (_type)
        {
            case TriggerType.Obstacle:
                Constans.Gameplay.GameStop(false);
                break;
            case TriggerType.Boost:
                _booster.Invoke();
                break;
        }  
    }
}
enum TriggerType
{
    None,
    Obstacle,
    Boost
}
