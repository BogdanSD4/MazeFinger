using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boost : MonoBehaviour
{
    [SerializeField] private AudioClip _touchSound;
    [SerializeField] private Transform _useIcon;
    [SerializeField] private TextMeshProUGUI _amountText;
    [SerializeField] private int _boosterMultiplicator;

    private int _amount = 0;
    private void OnEnable()
    {
        if (PlayerPrefs.HasKey($"Booster{_boosterMultiplicator}"))
        {
            Amount = PlayerPrefs.GetInt($"Booster{_boosterMultiplicator}");
        }
    }
    public int Amount
    {
        get { return _amount; }
        set 
        {
            _amount = value;
            _amountText.text = _amount.ToString();
            PlayerPrefs.SetInt($"Booster{_boosterMultiplicator}", _amount);
        }
    }

    public void Deselect() => _useIcon.gameObject.SetActive(false);

    public void Touch()
    {
        Constans.AudioManager.PlayOneShot(_touchSound);

        if (Amount <= 0) return;

        if (_useIcon.gameObject.activeSelf)
        { 
            Deselect();
            Gameplay.CurrentMultiplier = 1;
        }
        else
        {
            Constans.BoostMenu.Deselect();
            _useIcon.gameObject.SetActive(true);
            Gameplay.CurrentMultiplier = _boosterMultiplicator;
            BoostMenu._boostPoint = this;
        }
    }

    public void AddBoost(int amount)
    {
        Amount += amount;
    }
}
