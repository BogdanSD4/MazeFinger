using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObstaclesLevel.StaticObs.Guns
{
    class LaserGun : WallGun
    {
        LaserGun()
        {
            _timer = 0;
        }

        public override void ShootDelay()
        {
            _shootDelay = Random.Range(1f, 1.5f);
        }
    }
}
