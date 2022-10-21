using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObstaclesLevel
{
    public class Move : Obstacles
    {
        [HideInInspector] public float _speed;
        public float _minLimit;
        public float _maxLimit;

        private void Update()
        {
            Moving();
        }

        public virtual void Moving() { }
    }
}
