using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIManager : Singleton<UIManager>, IUIManager
{
    [SerializeField] private List<PanelDTO> _panelDTOs = new List<PanelDTO>();
    private Dictionary<TypePanelUI,PanelBase> _mapper = new Dictionary<TypePanelUI, PanelBase>();

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    void OnValidate()
    {
        for (int i = 0; i < _panelDTOs.Count; i++)
        {
            _panelDTOs[i].name = _panelDTOs[i].type.ToString();
        }
    }

    private void Init()
    {
        for (int i = 0; i < _panelDTOs.Count; i++)
        {
            if (_mapper.ContainsKey(_panelDTOs[i].type) == false)
            {
                _mapper.Add(_panelDTOs[i].type, _panelDTOs[i].panel);
            }
            else Debug.LogWarning(_panelDTOs[i].type + "has been register !");
        }
    }

    public void Hide(TypePanelUI type, System.Action callBack = null)
    {
        if (_mapper.ContainsKey(type))
            _mapper[type].DeActiveMe(callBack);
        else Debug.LogWarning(type + "not register");
    }

    public void Show(TypePanelUI type, System.Action callBack = null)
    {
        if (_mapper.ContainsKey(type))
            _mapper[type].ActiveMe(callBack);
        else Debug.LogWarning(type + " not register");
    }

}


[System.Serializable]
public class PanelDTO
{
    [HideInInspector] public string name;
    public TypePanelUI type;
    public PanelBase panel;
}

