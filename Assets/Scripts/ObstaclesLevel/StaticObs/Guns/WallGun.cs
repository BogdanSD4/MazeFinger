using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObstaclesLevel
{
    public class WallGun : Static
    {
        public float _fireSpeed;
        public Transform _handler;
        public Bullet _bulletPrefab;

        [HideInInspector] public float _timer = 3;
        [HideInInspector] public float _shootDelay;
        
        public override void Position()
        {
            _frame.position += new Vector3(3.25f * _side, 0, -1);
            _frame.localScale = new Vector3(
                transform.localScale.x * _side,
                transform.localScale.y,
                transform.localScale.z);

            ShootDelay();
        }
        public virtual void ShootDelay() { }
        private void Update()
        {
            _timer += Time.deltaTime;
            if(_timer >= _shootDelay)
            {
                _timer = 0;

                Shoot();
            }
        }

        public virtual void Shoot()
        {
            Bullet bullet = Instantiate(_bulletPrefab, _handler.position,
                    Quaternion.identity, _handler);
            bullet._speed = _fireSpeed;
        }
    }
}

