using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Transform _frame;
    [HideInInspector] public float _placingVertical;
    [HideInInspector] public int _side;

    private void Start()
    {
        int i;
        if ((i = Random.Range(0, 2)) == 0) _side = -1;
        else _side = 1;

        Position();
        ScreenSize();
    }

    public virtual void Position() { }
    public virtual void ScreenSize()
    {
        float scale = (Constans.RealCameraHeight / Gameplay.CameraSize) / 
            Constans.RealCameraWidth;

        transform.localScale = new Vector3(scale, scale, scale);
    }
}
