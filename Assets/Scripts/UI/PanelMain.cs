using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelMain : PanelBase
{
    [SerializeField] private Button btnUp;
    [SerializeField] private Button btnDown;
    void Start()
    {
        btnUp.onClick.AddListener(ClickUp);
    }

    void ClickUp()
    {

    }
   
}
