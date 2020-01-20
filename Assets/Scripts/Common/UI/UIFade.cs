using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
public class UIFade : UIElementAnim
{
    [SerializeField] private Color m_hideValue = default;
    [SerializeField] private Color m_showValue = default;
    private Image m_curImg;

    private void Awake()
    {
        m_curImg = GetComponent<Image>();
        Tweener = m_curImg.DOColor(m_showValue, Duration);
        Tweener.SetEase(Ease.Linear);
    }

    public override void Hide()
    {

    }

    public override void Show()
    {
        gameObject.SetActive(true);
        if(Tweener == null)
        {
            m_curImg = GetComponent<Image>();
            Tweener = m_curImg.DOColor(m_showValue, Duration);
            Tweener.SetEase(Ease.Linear);
        }
        Tweener.ChangeValues(m_hideValue, m_showValue);
        Tweener.Play();
    }
}
