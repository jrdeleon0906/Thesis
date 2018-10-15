using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuScript : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData.button);
    }
}
