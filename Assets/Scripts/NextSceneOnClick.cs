using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextSceneOnClick : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(ConstStrings.MainMenuScene);
    }
}
