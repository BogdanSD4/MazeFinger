using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObstaclesLevel
{
    public class HorizontalPlane : Move
    {
        public override void Position()
        {
            _frame.position += new Vector3(Random.Range(-2.8f, 2.8f), 0, -1);
        }
        public override void Moving()
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                new Vector3(_side == 1 ? _maxLimit : _minLimit, transform.position.y, -1), 
                Gameplay.GameSpeed * Time.deltaTime);

            if(transform.position.x == _maxLimit | transform.position.x == _minLimit)
            {
                _side *= -1;
            }
        }
    }
}
