using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObstaclesLevel
{
    public class Bullet : Move
    {
        public float _lifeTime;
        public override void Moving()
        {
            transform.Translate(-Gameplay.GameSpeed * Time.deltaTime * _speed, 0, 0);

            _lifeTime -= Time.deltaTime;
            if (_lifeTime <= 0) Destroy(this.gameObject);
        }

        public override void ScreenSize() { }
    }
}
