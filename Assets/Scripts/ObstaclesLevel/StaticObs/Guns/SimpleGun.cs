using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObstaclesLevel.StaticObs.Guns
{
    class SimpleGun : WallGun
    {
        public override void ShootDelay()
        {
            _shootDelay = Random.Range(.4f, .8f);
        }
    }
}
