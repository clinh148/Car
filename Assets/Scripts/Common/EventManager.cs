using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    //Delegate
    public delegate void OnUpdateScore();
    public delegate void OnUpdateCoin();

    //Event
    public static event OnUpdateScore _onUpdateScore;
    public static event OnUpdateCoin _onUpdateCoin;

    public static void UpdateScore()
    {
        _onUpdateScore?.Invoke();
    }


    public static void UpdateCoin()
    {
        _onUpdateCoin?.Invoke();
    }
}
