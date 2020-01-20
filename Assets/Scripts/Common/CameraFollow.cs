using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : Singleton<CameraFollow>
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;



    public void DoFollow()
    {
        if (_target == null)
            return;

        transform.DOMove(_target.transform.position + _offset,1f);
    }

}



