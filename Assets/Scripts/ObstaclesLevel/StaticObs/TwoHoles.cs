using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObstaclesLevel
{
    public class TwoHoles : Static
    {
        [SerializeField] private Transform _middlePlane;

        public override void Position()
        {
            _middlePlane.position += new Vector3(Random.Range(-.8f, .8f), 0, 0);

            _frame.position += new Vector3(Random.Range(-1.6f, 1.6f), 0, -1);
        }
    }
}
