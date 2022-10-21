using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private AudioClip _gameOverClip;
    [SerializeField] private UnityEvent _gameOver;
    public TextMeshProUGUI _console;

    public static float GameSpeed = 1;
    public static bool GameStarted;
    public static int CurrentBoost;
    public static int CurrentMultiplier = 1;

    private float _timer;
    private float _gameTimer;
    private bool _touchUpLose = true;

    private float _score;

    public static float CameraSize;
    private void Awake()
    {
        CameraSize =
        ((float)Camera.main.scaledPixelHeight /
        (float)Camera.main.scaledPixelWidth);
    }
    private void Update()
    {
        if (GameStarted)
        {
            if (!_touchUpLose) _touchUpLose = true;

            _timer += Time.deltaTime;
            _gameTimer += Time.deltaTime;

            if(_timer > (1/ GameSpeed))
            {
                _timer = 0;
                _score += GameSpeed * CurrentMultiplier;

                Constans.Interface.GameScore = Mathf.RoundToInt(_score).ToString();
            }

            if (_gameTimer >= 15)
            {
                _gameTimer = 0;
                GameSpeed *= 1.05f;
            }

#if !UNITY_EDITOR
            if(Input.touchCount == 0)
            {
                GameStop(false);
            }
#else
            if (Input.GetMouseButtonUp(0) && _touchUpLose)
            {
                GameStop(false);
            }
#endif 
        }
    }

    public void GameStop(bool state)
    {
        if (!state) _gameOver.Invoke();
        GameStarted = state;
        Constans.AudioManager.PlayOneShot(_gameOverClip);
    }

    public void GameOver()
    {
        Constans.Interface.SetHighScore(Mathf.RoundToInt(_score));
        ContinueGame._repeatCount = 1;
        GameStarted = false;
        GameSpeed = 1;
        CurrentMultiplier = 1;
        _touchUpLose = false;
        _score = 0;
    }

    public void Restart()
    {
        foreach(Transform i in Constans.LevelScroll)
        {
            Destroy(i.gameObject);
        }

        PiceOfLevel pol = Instantiate(Constans.LevelPrefab.GetComponent<PiceOfLevel>(),
            Constans.LevelScroll.position, Quaternion.identity, Constans.LevelScroll);
       
        pol.ClearObstacles();
    }

    [ContextMenu("DellPlayerPrefs")]
    private void DellPlayerPrefs() => PlayerPrefs.DeleteAll();
    [ContextMenu("CameraSize")]
    private void CamSize() => Debug.Log(CameraSize);
}
