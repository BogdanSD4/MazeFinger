using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private Transform _muteIconMusic;
    [Space]
    [SerializeField] private AudioSource _sfx;
    [SerializeField] private Transform _muteIconSFX;

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            if (PlayerPrefs.HasKey("SettingsMusic"))
            {
                bool state = BoolToInt(PlayerPrefs.GetInt("SettingsMusic"));

                _music.mute = state;
                _muteIconMusic.gameObject.SetActive(state);
            }
            else _music.mute = false;

            if (PlayerPrefs.HasKey("SettingsSFX"))
            {
                bool state = BoolToInt(PlayerPrefs.GetInt("SettingsSFX"));

                _sfx.mute = state;
                _muteIconSFX.gameObject.SetActive(state);
            }
            else _sfx.mute = false;
        }
        else
        {
            PlayerPrefs.SetInt("SettingsMusic", BoolToInt(_music.mute));
            PlayerPrefs.SetInt("SettingsSFX", BoolToInt(_sfx.mute));
        }
    }


    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("SettingsMusic", BoolToInt(_music.mute));
        PlayerPrefs.SetInt("SettingsSFX", BoolToInt(_sfx.mute));
    }

    private int BoolToInt(bool parameter)
    {
        if (parameter) return 1;
        else return 0;
    }

    private bool BoolToInt(int parameter)
    {
        if (parameter == 1) return true;
        else return false;
    }

}
