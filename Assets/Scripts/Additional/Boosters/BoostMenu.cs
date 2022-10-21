using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMenu : MonoBehaviour
{
    [SerializeField] private List<Boost> _boosts;
    [SerializeField] private Transform _menu;

    public static Boost _boostPoint;
    public void Touch()
    {
        if (_menu.gameObject.activeSelf) _menu.gameObject.SetActive(false);
        else _menu.gameObject.SetActive(true);
    }

    public void Deselect()
    {
        foreach(var i in _boosts)
        {
            i.Deselect();
        }
        _boostPoint = null;
    }

    public void MinusBoostAmount()
    {
        if(_boostPoint != null) _boostPoint.Amount--;

        Deselect();
    }
}
