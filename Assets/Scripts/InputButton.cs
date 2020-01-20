using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public enum TypeButton
{
    Accelerate = 0,
    Brake,
    Left,
    Right

}
public class InputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public TypeButton typeButton;
    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (typeButton == TypeButton.Brake)
        {
            if (!GameManager.I.car.handbrake)
            {
                GameManager.I.car.handbrake = true;
            }
            else
            {
                GameManager.I.car.handbrake = false;
                GameManager.I.car.throttle = -1f;
            }
        }
        else if (typeButton == TypeButton.Accelerate)
        {
            GameManager.I.car.handbrake = false;
            GameManager.I.car.throttle = 1f;
        }
        else if (typeButton == TypeButton.Left)
        {
            GameManager.I.car.inputSteering = -1;
        }
        else if (typeButton == TypeButton.Right)
        {
            GameManager.I.car.inputSteering = 1;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.I.car.throttle = 0;
        GameManager.I.car.inputSteering = 0;
        if (typeButton == TypeButton.Brake)
            GameManager.I.car.handbrake = true;
        else if (typeButton == TypeButton.Accelerate)
            GameManager.I.car.handbrake = false;
    }
}
