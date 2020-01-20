using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeObject : MonoBehaviour
{
    [SerializeField] private bool _freezePosX;
    [SerializeField] private bool _freezePosY;
    [SerializeField] private bool _freezePosZ;

    [SerializeField] private bool _freezeRotX;
    [SerializeField] private bool _freezeRotY;
    [SerializeField] private bool _freezeRotZ;

    [SerializeField] private bool _freezeScaleX;
    [SerializeField] private bool _freezeScaleY;
    [SerializeField] private bool _freezeScaleZ;

    [Space]
    [SerializeField] private Vector3 _posFreeze;
    [SerializeField] private Vector3 _rotFreeze;
    [SerializeField] private Vector3 _scaleFreeze;


    public float _thresold=0.1f;
    private void LateUpdate()
    {
        //Pos
        if (_freezePosX && Mathf.Abs(transform.position.x - _posFreeze.x) > _thresold)
            transform.position = new Vector3(_posFreeze.x, transform.position.y, transform.position.z);

        if (_freezePosY && Mathf.Abs(transform.position.y - _posFreeze.y) > _thresold)
            transform.position = new Vector3(transform.position.x, _posFreeze.y, transform.position.z);

        if (_freezePosZ && Mathf.Abs(transform.position.z - _posFreeze.z) > _thresold)
            transform.position = new Vector3(transform.position.x, transform.position.y, _posFreeze.z);

        //Rot
        if (_freezeRotX && Mathf.Abs(transform.rotation.eulerAngles.x - _rotFreeze.x) > _thresold)
            transform.rotation = Quaternion.Euler(new Vector3(_rotFreeze.x, transform.rotation.y, transform.rotation.z));

        if (_freezeRotY && Mathf.Abs(transform.rotation.eulerAngles.y - _rotFreeze.y) > _thresold)
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, _rotFreeze.y, transform.rotation.z));

        if (_freezeRotZ && Mathf.Abs(transform.rotation.eulerAngles.z - _rotFreeze.z) > _thresold)
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, _rotFreeze.z));

        //Scale
        if (_freezeScaleX && Mathf.Abs(transform.localScale.x - _scaleFreeze.x) > _thresold)
            transform.localScale = new Vector3(_scaleFreeze.x, transform.localScale.y, transform.localScale.z);

        if (_freezeScaleY && Mathf.Abs(transform.localScale.y - _scaleFreeze.y) > _thresold)
            transform.localScale = new Vector3(transform.localScale.x, _scaleFreeze.y, transform.localScale.z);

        if (_freezeScaleZ && Mathf.Abs(transform.localScale.z - _scaleFreeze.z) > _thresold)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, _scaleFreeze.z);
    }
}
