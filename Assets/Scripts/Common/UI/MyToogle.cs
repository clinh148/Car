using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MyToogle : MonoBehaviour
{
    [SerializeField] private bool isSave=false;
    public Sprite spriteOn;
    public Sprite spriteOff;

    public bool IsOn { get; set; }
    public Action<bool> actionOnChange;

    private Button m_myBtn;
    private Image m_myImg;

    private void Awake()
    {
        m_myBtn = GetComponent<Button>();
        m_myImg = GetComponent<Image>();
    }

    private void Start()
    {
        m_myBtn.onClick.AddListener(OnClick);
        if (isSave)
            IsOn = PlayerPrefs.GetInt("DataToogle" + gameObject.name, 1) == 1 ? true : false;
        else
            IsOn = true;

        if (spriteOn && spriteOff)
            m_myImg.sprite = IsOn == true ? spriteOn : spriteOff;
        //actionOnChange?.Invoke(IsOn);
    }

    private void OnClick()
    {
        IsOn = !IsOn;
        if (isSave)
            PlayerPrefs.SetInt("DataToogle" + gameObject.name, IsOn == true ? 1 : 0);

        if (spriteOn && spriteOff)
            m_myImg.sprite = IsOn == true ? spriteOn : spriteOff;
        actionOnChange?.Invoke(IsOn);
    }
}
