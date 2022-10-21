using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.ObstaclesLevel.StaticObs
{
    public class GameBooster : Static
    {
        [SerializeField] private AudioClip _useSound;
        [SerializeField] private float duration;
        [SerializeField] private int factor;
        [SerializeField] private UnityEvent _boostActiv;

        public override void Position()
        {
            _placingHorizontal = Random.Range(-2f, 2f);

            _placingVertical = Random.Range(-4.5f, 4.5f);

            if (_placingVertical >= -1.3f && _placingVertical <= 1.3f)
                Destroy(gameObject);

            transform.localPosition = new Vector3(_placingHorizontal, _placingVertical, -1);
        }

        public void BoostActiv()
        {
            _boostActiv.Invoke();
            Constans.AudioManager.PlayOneShot(_useSound);
        }
        public void Factor()
        {
            Constans.BoostTimer.Activate(duration, factor);
            Destroy(gameObject);
        }

        public void FreeSpin()
        {
            Constans.LuckySpin.SpinAmount++;
            Destroy(gameObject);
        }
    }
}
