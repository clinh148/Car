using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VisibleEvent : MonoBehaviour
{
    private Action _myAction;
    private void OnBecameInvisible()
    {
        _myAction?.Invoke();
    }


    public void SetAction(Action action)
    {
        _myAction = action;
    }
}
