using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector] public bool pressed;
    [HideInInspector] public bool fired;

    void Start()
    {
        pressed = false;
        fired = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
       
    }

}
