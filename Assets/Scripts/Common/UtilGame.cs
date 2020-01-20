using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilGame
{
    public static bool CheckTouchUI()
    {

#if UNITY_EDITOR
        //if (Input.GetMouseButtonDown (0)) {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            return true;
            //	}
        }

#elif UNITY_ANDROID || UNITY_IOS
		Touch[] lsttouch = Input.touches;
		if (lsttouch.Length > 0) {
		for (int i = 0; i < lsttouch.Length; i++) {
		if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject (lsttouch [i].fingerId)) {
		return true;
		}
		}
		}
#endif
        return false;
    }
}
