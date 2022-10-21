using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObstaclesLevel.MoveObs
{
    class LaserBullet : Bullet
    {
        public override void ScreenSize()
        {
            float scale = (Constans.RealCameraHeight / Gameplay.CameraSize) /
                 Constans.RealCameraWidth;

            transform.localScale = 
                new Vector3(transform.localScale.x, scale, scale);
        }
    }
}
