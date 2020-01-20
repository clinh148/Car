using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour, IActive
{
    [SerializeField] PanelAnim _anim;
    public virtual void ActiveMe(System.Action callBack)
    {
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
        if (_anim != null)
            _anim.Show(() =>
            {
                callBack?.Invoke();
            });
        else
        {
            callBack?.Invoke();
        }
    }

    public virtual void DeActiveMe(System.Action callBack)
    {
        if (_anim != null)
            _anim.Hide(() =>
            {
                if (gameObject.activeSelf)
                    gameObject.SetActive(false);
                callBack?.Invoke();
            });
        else
        {
            if (gameObject.activeSelf)
                gameObject.SetActive(false);
            callBack?.Invoke();
        }
    }
}
