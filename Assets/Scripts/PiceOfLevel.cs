using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.ObstaclesLevel.StaticObs;

public class PiceOfLevel : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _image;
    [Space]
    [SerializeField] private List<Obstacles> _obstacles;
    [Space]
    [SerializeField] private List<Boosters> _gameBoosters;

    private float _limitY = 10.3f;
    private bool _spawn;

    private void Start()
    {
        _image.size = new Vector2(Constans.CurrentCameraHeight / 
            Gameplay.CameraSize, _image.size.y);

        SpawnBooster();
        SpawnObstacles();
    }
    private void Update()
    {
        if (Gameplay.GameStarted)
        {
            if(transform.position.y <= 0 && !_spawn)
            {
                LevelContinue();
                _spawn = true;
            }
            
            if(transform.position.y <= -_limitY && _spawn)
            {
                Destroy(this.gameObject);
            }

            transform.Translate(0, -Gameplay.GameSpeed * 10 * Time.deltaTime , 0);
        }
    }

    private void LevelContinue()
    {
        Transform tr = Instantiate(Constans.LevelPrefab, transform.position, 
            Quaternion.identity ,Constans.LevelScroll);
        tr.localPosition += new Vector3(0, _limitY);
    }

    private void SpawnObstacles()
    {
        if (_obstacles.Count == 0) return;

        Instantiate(_obstacles[Random.Range(0, _obstacles.Count)],
            transform.position, Quaternion.identity, transform);
    }

    private void SpawnBooster()
    {
        if (_gameBoosters.Count == 0) return;

        var chance = Random.Range(0, 100f);
        var index = Random.Range(0, _gameBoosters.Count);

        if(chance < _gameBoosters[index].chance)
        {
            Instantiate(_gameBoosters[index].booster, transform);
        }
    }

    public void ClearObstacles()
    {
        _obstacles = new List<Obstacles>();
        _gameBoosters = new List<Boosters>();
    }
}

[System.Serializable]
public class Boosters
{
    public GameBooster booster;
    public float chance;
}
