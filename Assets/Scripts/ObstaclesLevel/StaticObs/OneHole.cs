using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObstaclesLevel
{
    class OneHole : Static
    {
        private float _holeSize;
        [SerializeField] private Transform _rightPlane;
        [SerializeField] private Transform _leftPlane;

        public override void Position()
        {
            Vector3 distanse = new Vector3(_holeSize = Random.Range(1, 1.5f), 0);

            _leftPlane.position -= distanse;
            _rightPlane.position += distanse;

            _frame.position += new Vector3(_placingHorizontal = Random.Range(-2.3f, 2.3f), 0, -1);
        }
    } 
}
