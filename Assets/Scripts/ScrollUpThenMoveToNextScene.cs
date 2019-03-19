using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ScrollUpThenMoveToNextScene : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(ConstStrings.MainMenuScene);
    }

    public void Update()
    {
        transform.localPosition += transform.up * 1f;
        if (transform.localPosition.y >= 500)
        {
            SceneManager.LoadScene(ConstStrings.MainMenuScene);
        }
    }
}
