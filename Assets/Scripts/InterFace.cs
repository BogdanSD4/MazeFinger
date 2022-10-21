using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterFace : MonoBehaviour
{
    [SerializeField] private List<GameObject> _menus;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _highScore;
    [SerializeField] private Animator _anim;
    [Space]
    [SerializeField] private TextMeshProUGUI _factor;
    [SerializeField] private GameObject _factorBox;

    public static int HighScore;

    public Animator InterfaceAnim => _anim;
    public void StartGame(bool state)
    {
        if (!state)
        {
            Gameplay.GameStarted = true;
            _anim.SetTrigger("Start");
        }
        else
        {
            _anim.SetTrigger("End");
        }

        _score.text = "0";
        SetMultip();
    }

    public string GameScore { set { _score.text = value; } }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
        else
        {
            if (PlayerPrefs.HasKey("HighScore"))
            {
                SetHighScore(PlayerPrefs.GetInt("HighScore"));
            }
        }
    }

    public void SetHighScore(int score)
    {
        if (score > HighScore) HighScore = score;

        _highScore.text = HighScore.ToString();
    }

    public void SetMultip()
    {
        if (!_factorBox.activeSelf)
        {
            _factorBox.SetActive(true);
        }

        if(Gameplay.CurrentMultiplier == 1) 
                _factorBox.SetActive(false);

        _factor.text = $"x{Gameplay.CurrentMultiplier}";
    }

    public void AnimAudio(AudioClip clip) => Constans.AudioManager.PlayOneShot(clip);
}
