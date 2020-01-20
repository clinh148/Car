using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class UIMove : UIElementAnim
{
    [SerializeField] private Vector3 m_hidePos = default;
    [SerializeField] private Vector3 m_showPos = default;
    private RectTransform m_curTrf;

    public Vector3 _HidePos { get; set; }
    public Vector3 _ShowPos { get; set; }

    protected void Awake()
    {
        m_curTrf = GetComponent<RectTransform>();
        _ShowPos = m_showPos;
        _HidePos = m_hidePos;
        Tweener = m_curTrf.DOAnchorPos3D(_ShowPos, Duration);
        Tweener.SetEase(Ease.Linear);
    }

    public override void Hide()
    {
        {
            //    m_curTrf = GetComponent<RectTransform>();
            //     _ShowPos = m_showPos;
            //    _HidePos = m_hidePos;
            Tweener = m_curTrf.DOAnchorPos3D(_HidePos, Duration);
            Tweener.SetEase(Ease.Linear);
        }
        Tweener.ChangeValues(_ShowPos, _HidePos);
        Tweener.Play();
    }

    public override void Show()
    {
        //gameObject.SetActive(true);
        //if (Tweener == null)
        {
        //    m_curTrf = GetComponent<RectTransform>();
       //     _ShowPos = m_showPos;
        //    _HidePos = m_hidePos;
            Tweener = m_curTrf.DOAnchorPos3D(_ShowPos, Duration);
            Tweener.SetEase(Ease.Linear);
        }
        Tweener.ChangeValues(_HidePos, _ShowPos);
        Tweener.Play();
    }

}
