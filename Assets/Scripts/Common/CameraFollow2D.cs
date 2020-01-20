using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow2D : Singleton<CameraFollow2D>
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _timeFollowY;
    [SerializeField] private float _timeFollowX;
    [SerializeField] private float _valueFollowingY;
    [SerializeField] private float _valueFollowing;

    private bool _isFollowingY;
    private bool _isFollowing;
    protected override void Awake()
    {
        base.Awake();
        if(Static.PosXScreen==0)
            Static.PosXScreen = Mathf.Abs(Camera.main.ViewportToWorldPoint(Vector3.zero).x);
    }

    [ContextMenu("UpdateCam")]
    public void FollowY()
    {
        if (_isFollowingY == false && _isFollowing == false)
            transform.DOMoveY(_target.position.y + _offset.y, _timeFollowY);
    }

    public void FollowX()
    {
        if (_isFollowingY == false && _isFollowing == false)
            transform.DOMoveX(_target.position.x + _offset.x, _timeFollowX);
    }

    public void FollowingY(bool b)
    {
        if (b)
            DOTween.Kill(transform);
        _isFollowingY = b;
    }

    public void Following(bool b)
    {
        if (b)
        {
            DOTween.Kill(transform);
        }
        _isFollowing = b;
    }

    private void LateUpdate()
    {
        if (_isFollowingY)
        {
            float posMoveToY = _target.position.y+ _offset.y ;
            float currentPosY = transform.position.y;
            currentPosY = Mathf.Lerp(currentPosY, posMoveToY, _valueFollowingY * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, currentPosY, transform.position.z);
        }
        else if (_isFollowing)
        {
            float posMoveToY = _target.position.y+ _offset.y ;
            float currentPosY = transform.position.y;
            currentPosY = Mathf.Lerp(currentPosY, posMoveToY, _valueFollowing * Time.deltaTime);
            transform.position = new Vector3(_target.position.x, currentPosY, transform.position.z);
        }
    }
}
